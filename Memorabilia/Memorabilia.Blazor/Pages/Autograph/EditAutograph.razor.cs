#nullable disable

namespace Memorabilia.Blazor.Pages.Autograph
{
    public partial class EditAutograph : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int AutographId { get; set; }     

        [Parameter]
        public int MemorabiliaId { get; set; }       

        private bool _displayAcquisitionDetails = true;
        private bool _displayEstimatedValue = true;
        private bool _displayNumbered;
        private bool _displayPersonalization;
        private bool _displayPersonImport;
        private SaveAutographViewModel _viewModel = new ();

        protected async Task OnLoad()
        {
            var viewModel = await QueryRouter.Send(new GetMemorabiliaItem.Query(MemorabiliaId)).ConfigureAwait(false);

            _displayPersonImport = viewModel.People.Any() && viewModel.People.Count() == 1;            

            if (viewModel.Autographs.Any())
            {
                if (AutographId == 0)
                {
                    _viewModel = new SaveAutographViewModel(viewModel);
                    SetDefaults();
                    return;
                }

                GetViewModel(viewModel);
            }
            else
            {
                _viewModel = new SaveAutographViewModel(viewModel);
                SetDefaults();
            }
        }

        protected async Task OnSave()
        {
            var command = new SaveAutograph.Command(_viewModel);

            await CommandRouter.Send(command).ConfigureAwait(false);

            _viewModel.ContinueNavigationPath = $"Autographs/Inscriptions/Edit/{command.Id}";
        }

        private void AcquisitionDetailsCheckboxClicked(bool isChecked)
        {
            _displayAcquisitionDetails = !isChecked;

            if (!_displayAcquisitionDetails)
            {
                _viewModel.AcquisitionTypeId = 0;
                _viewModel.AcquiredDate = null;
                _viewModel.Cost = null;
                _viewModel.PurchaseTypeId = 0;
            }
        }

        private void EstimatedValueCheckboxClicked(bool isChecked)
        {
            _displayEstimatedValue = !isChecked;

            if (!_displayEstimatedValue)
                _viewModel.EstimatedValue = null;
        }

        private void GetViewModel(MemorabiliaItemViewModel viewModel)
        {
            var autograph = AutographId == -1
                ? viewModel.Autographs.FirstOrDefault()
                : viewModel.Autographs.SingleOrDefault(autograph => autograph.Id == AutographId);

            if (autograph == null)
            {
                _viewModel = new SaveAutographViewModel(viewModel);
                _displayNumbered = _viewModel.IsNumbered;
                SetDefaults();
                return;
            }

            _viewModel = new SaveAutographViewModel(autograph);

            _displayAcquisitionDetails = _viewModel.AcquisitionTypeId > 0;
            _displayEstimatedValue = _viewModel.EstimatedValue.HasValue;
            _displayNumbered = _viewModel.IsNumbered;
            _displayPersonalization = !_viewModel.PersonalizationText.IsNullOrEmpty();
            _displayPersonImport = _viewModel.MemorabiliaPerson?.Id > 0;
        }

        private void NumberedCheckboxClicked(bool isChecked)
        {
            _displayNumbered = isChecked;

            if (!_displayNumbered)
            {
                _viewModel.Denominator = null;
                _viewModel.Numerator = null;
            }
        }

        private void OnImportAcquisitionClick()
        {
            _viewModel.AcquisitionTypeId = _viewModel.MemorabiliaAcquisitionTypeId;
            _viewModel.AcquiredDate = _viewModel.MemorabiliaAcquiredDate;
            _viewModel.Cost = _viewModel.MemorabiliaCost;
            _viewModel.PurchaseTypeId = _viewModel.MemorabiliaPurchaseTypeId ?? 0;
        }

        private void OnImportPersonClick()
        {
            _viewModel.Person = new SavePersonViewModel(_viewModel.MemorabiliaPerson);
        }

        private void PersonalizationCheckboxClicked(bool isChecked)
        {
            _displayPersonalization = isChecked;
            _viewModel.PersonalizationText = isChecked ? $"To {_viewModel.UserFirstName}" : null;
        }

        private void SelectedPersonChanged(SavePersonViewModel person)
        {
            _viewModel.Person = person;
        }

        private void SetDefaults()
        {
            _viewModel.ConditionId = Domain.Constants.Condition.Pristine.Id;
        }
    }
}
