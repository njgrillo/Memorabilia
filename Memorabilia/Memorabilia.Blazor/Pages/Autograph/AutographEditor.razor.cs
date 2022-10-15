#nullable disable

namespace Memorabilia.Blazor.Pages.Autograph;

public partial class AutographEditor : AutographItem<SaveAutographViewModel>
{   

    [Parameter]
    public int MemorabiliaId { get; set; }       

    private bool _displayAcquisitionDetails = true;
    private bool _displayEstimatedValue = true;
    private bool _displayNumbered;
    private bool _displayPersonalization;
    private bool _displayPersonImport;

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetMemorabiliaItem.Query(MemorabiliaId));

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

    private void EstimatedValueCheckboxClicked(bool isChecked)
    {
        _displayEstimatedValue = !isChecked;

        if (!_displayEstimatedValue)
            ViewModel.EstimatedValue = null;
    }

    private void GetViewModel(MemorabiliaItemViewModel viewModel)
    {
        var autograph = AutographId == -1
            ? viewModel.Autographs.FirstOrDefault()
            : viewModel.Autographs.SingleOrDefault(autograph => autograph.Id == AutographId);

        if (autograph == null)
        {
            ViewModel = new SaveAutographViewModel(viewModel);
            _displayNumbered = ViewModel.IsNumbered;
            SetDefaults();
            return;
        }

        ViewModel = new SaveAutographViewModel(autograph);

        _displayAcquisitionDetails = ViewModel.AcquisitionTypeId > 0;
        _displayEstimatedValue = ViewModel.EstimatedValue.HasValue;
        _displayNumbered = ViewModel.IsNumbered;
        _displayPersonalization = !ViewModel.PersonalizationText.IsNullOrEmpty();
        _displayPersonImport = ViewModel.MemorabiliaPerson?.Id > 0;
    }

    private void NumberedCheckboxClicked(bool isChecked)
    {
        _displayNumbered = isChecked;

        if (!_displayNumbered)
        {
            ViewModel.Denominator = null;
            ViewModel.Numerator = null;
        }
    }

    private void OnImportAcquisitionClick()
    {
        ViewModel.AcquisitionTypeId = ViewModel.MemorabiliaAcquisitionTypeId;
        ViewModel.AcquiredDate = ViewModel.MemorabiliaAcquiredDate;
        ViewModel.Cost = ViewModel.MemorabiliaCost;
        ViewModel.PurchaseTypeId = ViewModel.MemorabiliaPurchaseTypeId ?? 0;
    }

    private void OnImportPersonClick()
    {
        ViewModel.Person = new SavePersonViewModel(ViewModel.MemorabiliaPerson);
    }

    private void PersonalizationCheckboxClicked(bool isChecked)
    {
        _displayPersonalization = isChecked;
        ViewModel.PersonalizationText = isChecked ? $"To {ViewModel.UserFirstName}" : null;
    }

    private void SelectedPersonChanged(SavePersonViewModel person)
    {
        ViewModel.Person = person;
    }

    private void SetDefaults()
    {
        ViewModel.ConditionId = Condition.Pristine.Id;
    }
}
