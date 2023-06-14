namespace Memorabilia.Domain.Entities;

public class User : Framework.Library.Domain.Entity.DomainEntity
{
    public User() { }

    public User(string emailAddress, string firstName, string lastName)
    {
        EmailAddress = emailAddress;
        FirstName = firstName;
        LastName = lastName;
        CreateDate = DateTime.UtcNow;
        UserRoleId = Constant.Role.User.Id;
    }

    public DateTime CreateDate { get; private set; }

    public virtual List<UserDashboard> DashboardItems { get; private set; }

    public string EmailAddress { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }   

    public DateTime? UpdateDate { get; private set; }

    public int UserRoleId { get; private set; }

    public void SetDashboardItems(params int[] dashboardItemsIds)
    {
        if (dashboardItemsIds == null || !dashboardItemsIds.Any())
            DashboardItems = new List<UserDashboard>();

        DashboardItems.RemoveAll(dashboardItemsId => !dashboardItemsIds.Contains(dashboardItemsId.DashboardItemId));
        DashboardItems.AddRange(dashboardItemsIds.Where(dashboardItemsId => !DashboardItems.Select(dashboardItemId => dashboardItemId.DashboardItemId)
                                                                                           .Contains(dashboardItemsId))
                                                 .Select(dashboardItemsId => new UserDashboard(Id, dashboardItemsId)));
    }
}
