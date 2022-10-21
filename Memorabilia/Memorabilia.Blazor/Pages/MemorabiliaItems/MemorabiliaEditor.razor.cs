#nullable disable

namespace Memorabilia.Blazor.Pages.MemorabiliaItems
{
    public partial class MemorabiliaEditor : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }        

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }        

        [Parameter]
        public int Id { get; set; }

        [Parameter]
        public int UserId { get; set; }

        private bool _canEditItemType = true;
        private bool _displayNumbered;
        private SaveMemorabiliaItemViewModel _viewModel = new ();        

        protected async Task OnLoad()
        {
            if (Id == 0)
            {
                SetDefaults();
                return;
            }

            _viewModel = new SaveMemorabiliaItemViewModel(await QueryRouter.Send(new GetMemorabiliaItem(Id)));
            _canEditItemType = false;
            _displayNumbered = _viewModel.IsNumbered;
        }

        protected async Task OnSave()
        {    
            if (UserId == 0)
                NavigationManager.NavigateTo("Login");

            _viewModel.UserId = UserId;

            var command = new SaveMemorabiliaItem.Command(_viewModel);

            await CommandRouter.Send(command);

            var itemTypeName = ItemType.Find(_viewModel.ItemTypeId).Name;
            _viewModel.ContinueNavigationPath = $"Memorabilia/{itemTypeName.Replace(" ", "")}/Edit/{command.Id}";
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

        private void SetDefaults()
        {
            _viewModel.AcquisitionTypeId = AcquisitionType.Purchase.Id;
            _viewModel.ConditionId = Condition.Pristine.Id;
            _viewModel.PrivacyTypeId = PrivacyType.Public.Id;
        }
    }
}
