namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public partial class MemorabiliaEditor
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Inject]
    public MemorabiliaItemValidator Validator { get; set; }        

    [Parameter]
    public int Id { get; set; }

    protected MemorabiliaEditModel EditModel
        = new();

    protected bool IsLoaded { get; set; }      

    protected override async Task OnInitializedAsync()
    {
        if (Id == 0)
        {
            IsLoaded = true;
            return;
        }

        EditModel = (await QueryRouter.Send(new GetMemorabiliaItem(Id))).ToEditModel();

        IsLoaded = true;
    }

    protected async Task Save()
    {
        EditModel.UserId = ApplicationStateService.CurrentUser.Id;

        var command = new SaveMemorabiliaItem.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        EditModel.ContinueNavigationPath = $"Memorabilia/{EditModel.ItemTypeName.Replace(" ", "")}/Edit/{command.Id}";
    }

    private void OnAcquisitionTypeChange(int acquisitionTypeId)
    {
        EditModel.AcquisitionTypeId = acquisitionTypeId;

        var acquisitionType = AcquisitionType.Find(acquisitionTypeId);

        if (!acquisitionType.CanHaveCost())
            EditModel.Cost = null;

        if (!acquisitionType.CanHavePurchaseType())
            EditModel.PurchaseTypeId = 0;
    }
}
