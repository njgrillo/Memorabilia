namespace Memorabilia.Application.Features.User.Dashboard;

public class UserDashboardsViewModel : ViewModel
{
    public UserDashboardsViewModel() { }

    public UserDashboardsViewModel(int userId, IEnumerable<Domain.Entities.UserDashboard> userDashboards)
    {
        UserId = userId;

        var userDashboardItems = userDashboards.Select(userDashboard => new UserDashboardViewModel(userDashboard))
                                               .ToList();

        var userDashboardItemIds = userDashboardItems.Select(userDashboard => userDashboard.DashboardItemId).ToArray();

        foreach (var dashboardItem in Constant.DashboardItem.All)
        {
            if (userDashboardItemIds.Contains(dashboardItem.Id))
            {
                var userDashboardItem = userDashboardItems.Single(userDashboardItem => userDashboardItem.DashboardItemId == dashboardItem.Id);
                userDashboardItem.IsSelected = true;
            }
            else
            {
                userDashboardItems.Add(new UserDashboardViewModel(new Domain.Entities.UserDashboard(UserId, dashboardItem.Id)));
            }
        }

        UserDashboards = userDashboardItems;
    }

    public List<UserDashboardViewModel> UserDashboards { get; set; } = new();

    public override string ItemTitle => "Manage Dashboard";

    public override string PageTitle => "Manage Dashboard";

    public override string RoutePrefix => "ManageDashboard";

    public int UserId { get; set; }
}
