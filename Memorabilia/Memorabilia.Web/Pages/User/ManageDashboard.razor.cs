using Demo.Framework.Web;
using Memorabilia.Application.Features.User.Dashboard;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using MudBlazor;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.User
{
    public partial class ManageDashboard : ComponentBase
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

        private SaveUserDashboardViewModel _viewModel = new();

        protected async Task HandleValidSubmit()
        {
            await CommandRouter.Send(new SaveUserDashboard.Command(_viewModel)).ConfigureAwait(false);

            NavigationManager.NavigateTo(_viewModel.ContinueNavigationPath);
            Snackbar.Add($"{_viewModel.PageTitle} was saved successfully!", Severity.Success);
        }

        protected async Task OnLoad()
        {
            var userId = await LocalStorage.GetAsync<int>("UserId").ConfigureAwait(false);

            if (userId.Value == 0)
                NavigationManager.NavigateTo("Login");

            _viewModel = new SaveUserDashboardViewModel(await QueryRouter.Send(new GetUserDashboardItems.Query(userId.Value)).ConfigureAwait(false));
        }
    }
}
