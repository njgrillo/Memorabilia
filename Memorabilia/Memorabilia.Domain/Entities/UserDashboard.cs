namespace Memorabilia.Domain.Entities;

public class UserDashboard : Framework.Library.Domain.Entity.DomainEntity
{
    public UserDashboard() { }

    public UserDashboard(int userId, int dashboardItemId)
    {
        DashboardItemId = dashboardItemId;
        UserId = userId;
    }

    public int DashboardItemId { get; private set; }

    public int UserId { get; private set; }

    public void Set(int userId, int dashboardItemId)
    {
        DashboardItemId = dashboardItemId;
        UserId = userId;
    }
}
