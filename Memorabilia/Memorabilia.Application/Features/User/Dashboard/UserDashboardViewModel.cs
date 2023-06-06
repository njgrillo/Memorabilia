using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.User.Dashboard;

public class UserDashboardViewModel
{
    private UserDashboard _userDashboard;

    public UserDashboardViewModel() { }

    public UserDashboardViewModel(UserDashboard userDashboard) 
    {
        _userDashboard = userDashboard;
    }

    public Constant.DashboardItem DashboardItem => Constant.DashboardItem.Find(_userDashboard.DashboardItemId);

    public int DashboardItemId => _userDashboard.DashboardItemId;   

    public string Description => DashboardItem?.Description;

    public bool IsSelected { get; set; }

    public string Name => DashboardItem?.Name;

    public int UserId => _userDashboard.UserId;
}
