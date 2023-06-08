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

    private MemorabiliaItemEditModel _viewModel = new ();        

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        _viewModel = new MemorabiliaItemEditModel(new MemorabiliaItemModel(await QueryRouter.Send(new GetMemorabiliaItem(Id))));
    }

    protected async Task OnSave()
    {    
        if (UserId == 0)
            NavigationManager.NavigateTo("Login");

        _viewModel.UserId = UserId;

        var command = new SaveMemorabiliaItem.Command(_viewModel);

        _viewModel.ValidationResult = Validator.Validate(command);

        if (!_viewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        _viewModel.ContinueNavigationPath = $"Memorabilia/{_viewModel.ItemTypeName.Replace(" ", "")}/Edit/{command.Id}";
    }

    private void OnAcquisitionTypeChange(int acquisitionTypeId)
    {
        _viewModel.AcquisitionTypeId = acquisitionTypeId;

        var acquisitionType = AcquisitionType.Find(acquisitionTypeId);

        if (!acquisitionType.CanHaveCost())
            _viewModel.Cost = null;

        if (!acquisitionType.CanHavePurchaseType())
            _viewModel.PurchaseTypeId = 0;
    }
}
