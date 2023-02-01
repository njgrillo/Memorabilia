namespace Memorabilia.Blazor.Pages.Autograph;

public partial class AutographEditor : AutographItem<SaveAutographViewModel>
{   
    [Parameter]
    public int MemorabiliaId { get; set; }

    [Parameter]
    public string UploadPath { get; set; }

    private bool _displayAcquisitionDetails = true;

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (!viewModel.Autographs.Any() || AutographId <= 0)
        {
            ViewModel = new SaveAutographViewModel(viewModel);
            return;
        }

        GetViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SaveAutograph.Command(ViewModel);

        await CommandRouter.Send(command);

        ViewModel.ContinueNavigationPath = $"Autographs/Inscriptions/{EditModeType.Update.Name}/{command.Id}";
    }

    private void GetViewModel(MemorabiliaItemViewModel viewModel)
    {
        var autograph = viewModel.Autographs.SingleOrDefault(autograph => autograph.Id == AutographId);

        if (autograph == null)
        {
            ViewModel = new SaveAutographViewModel(viewModel);
            return;
        }

        ViewModel = new SaveAutographViewModel(autograph);

        _displayAcquisitionDetails = ViewModel.AcquisitionTypeId > 0;
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
