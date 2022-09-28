namespace Memorabilia.Application.Features.User.Dashboard
{
    public class SaveUserDashboardViewModel : SaveViewModel
    {
        public SaveUserDashboardViewModel() { }

        public SaveUserDashboardViewModel(UserDashboardsViewModel userDashboardsViewModel)
        {
            UserDashboardItems = userDashboardsViewModel.UserDashboards;
            UserId = userDashboardsViewModel.UserId;
        }

        public override string BackNavigationPath => "Settings";

        public override string ContinueNavigationPath => "Settings";

        public override string ExitNavigationPath => "Settings";

        public override string ItemTitle => "Manage Dashboard";

        public override string PageTitle => "Manage Dashboard";

        public override string RoutePrefix => "ManageDashboard";

        public List<UserDashboardViewModel> UserDashboardItems { get; set; } = new();

        public int UserId { get; set; }
    }
}
