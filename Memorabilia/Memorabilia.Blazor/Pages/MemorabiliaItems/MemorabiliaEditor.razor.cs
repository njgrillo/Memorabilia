namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public partial class MemorabiliaEditor
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Inject]
    public MemorabiliaItemValidator Validator { get; set; }        

    [Parameter]
    public string EncryptId { get; set; }

    protected MemorabiliaEditModel EditModel
        = new();

    protected int Id { get; set; }

    protected bool IsLoaded { get; set; }

    private string _continueNavigationPath;

    protected override async Task OnInitializedAsync()
    {
        Id = EncryptId.IsNullOrEmpty()
            ? 0
            : DataProtectorService.DecryptId(EncryptId);

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

        _continueNavigationPath 
            = $"{NavigationPath.Memorabilia}/{EditModel.ItemTypeName.Replace(" ", "")}/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(command.Id)}";
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
