namespace Memorabilia.Application.Features.User.Dashboard;

public class UserDashboardModel
{
    private readonly Entity.UserDashboard _userDashboard;

    public UserDashboardModel() { }

    public UserDashboardModel(Entity.UserDashboard userDashboard) 
    {
        _userDashboard = userDashboard;
    }

    public Constant.DashboardItem DashboardItem 
        => Constant.DashboardItem.Find(_userDashboard.DashboardItemId);

    public int DashboardItemId 
        => _userDashboard.DashboardItemId;   

    public string Description 
        => DashboardItem?.Description;

    public bool IsSelected { get; set; }

    public string Name 
        => DashboardItem?.Name;

    public int UserId 
        => _userDashboard.UserId;
}
