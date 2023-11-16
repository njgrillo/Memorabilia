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

    public List<UserDashboardModel> UserDashboardItems { get; set; } 
        = [];

    public int UserId { get; set; }
}
