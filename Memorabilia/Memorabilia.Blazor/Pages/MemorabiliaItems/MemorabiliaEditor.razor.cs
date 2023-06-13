namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public partial class MemorabiliaEditor
{
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

    [Parameter]
    public int UserId { get; set; }

    protected MemorabiliaEditModel Model 
        = new ();        

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        Model = (await QueryRouter.Send(new GetMemorabiliaItem(Id))).ToEditModel();
    }

    protected async Task OnSave()
    {    
        if (UserId == 0)
            NavigationManager.NavigateTo("Login");

        Model.UserId = UserId;

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
