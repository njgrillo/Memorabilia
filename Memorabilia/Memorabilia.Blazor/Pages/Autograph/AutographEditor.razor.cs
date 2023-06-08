namespace Memorabilia.Blazor.Pages.Autograph;

public partial class AutographEditor 
    : AutographItem<AutographEditModel>
{
    [Inject]
    public AutographValidator Validator { get; set; }

    [Parameter]
    public int MemorabiliaId { get; set; }

    [Parameter]
    public string UploadPath { get; set; }

    private bool _displayAcquisitionDetails = true;

    protected async Task OnLoad()
    {
        var viewModel = new MemorabiliaItemModel(await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId)));

        if (!viewModel.Autographs.Any() || AutographId <= 0)
        {
            ViewModel = new AutographEditModel(viewModel);
            return;
        }

        GetViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SaveAutograph.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.ContinueNavigationPath = $"Autographs/Inscriptions/{EditModeType.Update.Name}/{command.Id}";
    }

    private void GetViewModel(MemorabiliaItemModel viewModel)
    {
        var autograph = viewModel.Autographs.SingleOrDefault(autograph => autograph.Id == AutographId);

        if (autograph == null)
        {
            ViewModel = new AutographEditModel(viewModel);
            return;
        }

        ViewModel = new AutographEditModel(autograph);

        _displayAcquisitionDetails = ViewModel.AcquisitionTypeId > 0;
    }

    private void OnAcquisitionTypeChange(int acquisitionTypeId)
    {
        ViewModel.AcquisitionTypeId = acquisitionTypeId;

        var acquisitionType = AcquisitionType.Find(acquisitionTypeId);

        if (!acquisitionType.CanHaveCost())
            ViewModel.Cost = null;

        if (!acquisitionType.CanHavePurchaseType())
            ViewModel.PurchaseTypeId = 0;

        if (!acquisitionType.CanHaveSendAndReceiveDates())
        {
            ViewModel.ReceivedDate = null;
            ViewModel.SentDate = null;
        }
    }

    private void OnImportAcquisition()
    {
        ViewModel.AcquisitionTypeId = ViewModel.MemorabiliaAcquisitionTypeId;
        ViewModel.AcquiredDate = ViewModel.MemorabiliaAcquiredDate;
        ViewModel.Cost = ViewModel.MemorabiliaCost;
        ViewModel.PurchaseTypeId = ViewModel.MemorabiliaPurchaseTypeId ?? 0;
    }

    private void OnImportEstimatedValue()
    {
        ViewModel.EstimatedValue = ViewModel.MemorabiliaEstimatedValue;
    }
}
