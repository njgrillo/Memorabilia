using Demo.Framework.Web;
using Framework.Extension;
using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Application.Features.Autograph;
using Memorabilia.Application.Features.Memorabilia;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Autograph
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
                SetDefaults();
                return;
            }

            _viewModel = new SaveAutographViewModel(autograph);

            _displayAcquisitionDetails = _viewModel.AcquisitionTypeId > 0;
            _displayEstimatedValue = _viewModel.EstimatedValue.HasValue;
            _displayPersonalization = !_viewModel.PersonalizationText.IsNullOrEmpty();
            _displayPersonImport = _viewModel.MemorabiliaPerson?.Id > 0;
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
