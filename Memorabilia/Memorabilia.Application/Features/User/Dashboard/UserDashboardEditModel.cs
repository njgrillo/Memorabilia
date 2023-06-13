namespace Memorabilia.Application.Features.User.Dashboard;

public class UserDashboardEditModel : EditModel
{
    public UserDashboardEditModel() { }

    public UserDashboardEditModel(UserDashboardsModel model)
    {
        UserDashboardItems = model.UserDashboards;
        UserId = model.UserId;
    }

    public bool AllItemsSelected
        => UserDashboardItems.Count(item => item.IsSelected) == UserDashboardItems.Count;

    public override string BackNavigationPath 
        => "Settings";    

    public override string ContinueNavigationPath 
        => "Settings";

    public override string ExitNavigationPath 
        => "Settings";

    public override string ItemTitle 
        => "Manage Dashboard";

    public override string PageTitle 
        => "Manage Dashboard";

    public override string RoutePrefix 
        => "ManageDashboard";

    public List<UserDashboardModel> UserDashboardItems { get; set; } 
        = new();

    public int UserId { get; set; }
}
