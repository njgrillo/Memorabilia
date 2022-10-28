#nullable disable

namespace Memorabilia.Blazor.Pages.Autograph;

public partial class AutographEditor : AutographItem<SaveAutographViewModel>
{   

    [Parameter]
    public int MemorabiliaId { get; set; }       

    private bool _displayAcquisitionDetails = true;
    private bool _displayPersonImport;

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        _displayPersonImport = viewModel.People.Any() && viewModel.People.Count() == 1;            

        if (viewModel.Autographs.Any())
        {
            if (AutographId == 0)
            {
                ViewModel = new SaveAutographViewModel(viewModel);
                SetDefaults();
                return;
            }

            GetViewModel(viewModel);
        }
        else
        {
            ViewModel = new SaveAutographViewModel(viewModel);
            SetDefaults();
        }
    }

    protected async Task OnSave()
    {
        var command = new SaveAutograph.Command(ViewModel);

        await CommandRouter.Send(command);

        ViewModel.ContinueNavigationPath = $"Autographs/Inscriptions/{EditModeType.Update.Name}/{command.Id}";
    }

    private void AcquisitionDetailsCheckboxClicked(bool isChecked)
    {
        _displayAcquisitionDetails = !isChecked;

        if (!_displayAcquisitionDetails)
        {
            ViewModel.AcquisitionTypeId = 0;
            ViewModel.AcquiredDate = null;
            ViewModel.Cost = null;
            ViewModel.PurchaseTypeId = 0;
        }
    }

    private void GetViewModel(MemorabiliaItemViewModel viewModel)
    {
        var autograph = AutographId == -1
            ? viewModel.Autographs.FirstOrDefault()
            : viewModel.Autographs.SingleOrDefault(autograph => autograph.Id == AutographId);

        if (autograph == null)
        {
            ViewModel = new SaveAutographViewModel(viewModel);
            SetDefaults();
            return;
        }

        ViewModel = new SaveAutographViewModel(autograph);

        _displayAcquisitionDetails = ViewModel.AcquisitionTypeId > 0;
        _displayPersonImport = ViewModel.MemorabiliaPerson?.Id > 0;
    }

    private void OnImportAcquisitionClick()
    {
        ViewModel.AcquisitionTypeId = ViewModel.MemorabiliaAcquisitionTypeId;
        ViewModel.AcquiredDate = ViewModel.MemorabiliaAcquiredDate;
        ViewModel.Cost = ViewModel.MemorabiliaCost;
        ViewModel.PurchaseTypeId = ViewModel.MemorabiliaPurchaseTypeId ?? 0;
    }

    private void SetDefaults()
    {
        ViewModel.ConditionId = Condition.Pristine.Id;
    }
}
