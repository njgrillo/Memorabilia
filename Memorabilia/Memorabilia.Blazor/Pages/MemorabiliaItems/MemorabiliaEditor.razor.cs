namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public partial class MemorabiliaEditor : ImagePage
{   
    [Inject]
    public MemorabiliaItemValidator Validator { get; set; }        

    [Parameter]
    public int Id { get; set; }

    [Parameter]
    public int UserId { get; set; }

    private SaveMemorabiliaItemViewModel _viewModel = new ();        

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        _viewModel = new SaveMemorabiliaItemViewModel(await QueryRouter.Send(new GetMemorabiliaItem(Id)));
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

        if (acquisitionType != AcquisitionType.Purchase) 
        {
            _viewModel.Cost = null;
            _viewModel.PurchaseTypeId = 0;
        }
    }
}
