using Demo.Framework.Web;
using Memorabilia.Application.Features.Memorabilia;
using Memorabilia.Domain.Constants;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using MudBlazor;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.MemorabiliaItems
{
    public partial class EditMemorabilia : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public ProtectedLocalStorage LocalStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Parameter]
        public int Id { get; set; }

        private bool _canEditItemType = true;
        private SaveMemorabiliaItemViewModel _viewModel = new ();        

        protected async Task OnLoad()
        {
            if (Id == 0)
            {
                SetDefaults();
                return;
            }

            _viewModel = new SaveMemorabiliaItemViewModel(await QueryRouter.Send(new GetMemorabiliaItem.Query(Id)).ConfigureAwait(false));
            _canEditItemType = false;
        }

        protected async Task OnSave()
        {
            var userId = await LocalStorage.GetAsync<int>("UserId").ConfigureAwait(false);

            if (userId.Value == 0)
                NavigationManager.NavigateTo("Login");

            _viewModel.UserId = userId.Value;

            var command = new SaveMemorabiliaItem.Command(_viewModel);

            await CommandRouter.Send(command).ConfigureAwait(false);

            var itemTypeName = ItemType.Find(_viewModel.ItemTypeId).Name;
            _viewModel.ContinueNavigationPath = $"Memorabilia/{itemTypeName.Replace(" ", "")}/Edit/{command.Id}";
        }

        private void SetDefaults()
        {
            _viewModel.AcquisitionTypeId = AcquisitionType.Purchase.Id;
            _viewModel.ConditionId = Condition.Pristine.Id;
            _viewModel.PrivacyTypeId = PrivacyType.Public.Id;
        }
    }
}
