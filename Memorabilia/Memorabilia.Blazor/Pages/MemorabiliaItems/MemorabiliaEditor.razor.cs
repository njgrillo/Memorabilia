namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public partial class MemorabiliaEditor
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Inject]
    public MemorabiliaItemValidator Validator { get; set; }        

    [Parameter]
    public int Id { get; set; }

    protected MemorabiliaEditModel Model 
        = new ();        

    protected override async Task OnInitializedAsync()
    {
        if (Id == 0)
            return;

        Model = (await QueryRouter.Send(new GetMemorabiliaItem(Id))).ToEditModel();
    }

    protected async Task OnSave()
    {    
        Model.UserId = ApplicationStateService.CurrentUser.Id;

        var command = new SaveMemorabiliaItem.Command(Model);

        Model.ValidationResult = Validator.Validate(command);

        if (!Model.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        Model.ContinueNavigationPath = $"Memorabilia/{Model.ItemTypeName.Replace(" ", "")}/Edit/{command.Id}";
    }

    private void OnAcquisitionTypeChange(int acquisitionTypeId)
    {
        Model.AcquisitionTypeId = acquisitionTypeId;

        var acquisitionType = AcquisitionType.Find(acquisitionTypeId);

        if (!acquisitionType.CanHaveCost())
            Model.Cost = null;

        if (!acquisitionType.CanHavePurchaseType())
            Model.PurchaseTypeId = 0;
    }
}
