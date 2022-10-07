#nullable disable

namespace Memorabilia.Blazor.Pages.User
{
    public partial class ManageDashboard : ComponentBase
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
        public int UserId { get; set; }

        private SaveUserDashboardViewModel _viewModel = new();

        protected async Task HandleValidSubmit()
        {
            await CommandRouter.Send(new SaveUserDashboard.Command(_viewModel)).ConfigureAwait(false);

            NavigationManager.NavigateTo(_viewModel.ContinueNavigationPath);
            Snackbar.Add($"{_viewModel.PageTitle} was saved successfully!", Severity.Success);
        }

        protected async Task OnLoad()
        {
            if (UserId == 0)
                NavigationManager.NavigateTo("Login");

            _viewModel = new SaveUserDashboardViewModel(await QueryRouter.Send(new GetUserDashboardItems.Query(UserId)).ConfigureAwait(false));
        }
    }
}
