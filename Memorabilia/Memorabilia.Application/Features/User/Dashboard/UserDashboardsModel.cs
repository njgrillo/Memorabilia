namespace Memorabilia.Application.Features.User.Dashboard;

public class UserDashboardsModel : Model
{
    public UserDashboardsModel() { }

    public UserDashboardsModel(int userId, IEnumerable<Entity.UserDashboard> userDashboards)
    {
        UserId = userId;

        List<UserDashboardModel> userDashboardItems 
            = userDashboards.Select(userDashboard => new UserDashboardModel(userDashboard))
                            .ToList();

        int[] userDashboardItemIds = userDashboardItems.Select(userDashboard => userDashboard.DashboardItemId)
                                                       .ToArray();

        foreach (Constant.DashboardItem dashboardItem in Constant.DashboardItem.All)
        {
            if (userDashboardItemIds.Contains(dashboardItem.Id))
            {
                UserDashboardModel userDashboardItem 
                    = userDashboardItems.Single(userDashboardItem => userDashboardItem.DashboardItemId == dashboardItem.Id);
                
                userDashboardItem.IsSelected = true;
            }
            else
            {
                userDashboardItems.Add(new UserDashboardModel(new Entity.UserDashboard(UserId, dashboardItem.Id)));
            }
        }

        UserDashboards = userDashboardItems;
    }

    public List<UserDashboardModel> UserDashboards { get; set; } 
        = new();

    public override string ItemTitle
        => "Manage Dashboard";

    public override string PageTitle 
        => "Manage Dashboard";

    public override string RoutePrefix 
        => "ManageDashboard";

    public int UserId { get; set; }
}
