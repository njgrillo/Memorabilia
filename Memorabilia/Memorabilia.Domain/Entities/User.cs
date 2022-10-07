namespace Memorabilia.Domain.Entities;

public class User : Framework.Library.Domain.Entity.DomainEntity
{
    public User() { }

    public User(string username, string password, string emailAddress, string firstName, string lastName, string phone)
    {
        Username = username;
        Password = password;
        EmailAddress = emailAddress;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        CreateDate = DateTime.UtcNow;

        //Delete this later:
        RoleId = 1;
    }

    public DateTime CreateDate { get; private set; }

    public virtual List<UserDashboard> DashboardItems { get; private set; }

    public string EmailAddress { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Password { get; private set; }

    public string Phone { get; private set; }

    public int RoleId { get; private set; }

    public DateTime? UpdateDate { get; private set; }

    public string Username { get; private set; }

    public void SetDashboardItems(params int[] dashboardItemsIds)
    {
        if (dashboardItemsIds == null || !dashboardItemsIds.Any())
            DashboardItems = new List<UserDashboard>();

        DashboardItems.RemoveAll(dashboardItemsId => !dashboardItemsIds.Contains(dashboardItemsId.DashboardItemId));
        DashboardItems.AddRange(dashboardItemsIds.Where(dashboardItemsId => !DashboardItems.Select(dashboardItemId => dashboardItemId.DashboardItemId)
                                                                                           .Contains(dashboardItemsId))
                                                 .Select(dashboardItemsId => new UserDashboard(Id, dashboardItemsId)));
    }

    public void SetUser(string password, string emailAddress, string firstName, string lastName, string phone)
    {
        Password = password;
        EmailAddress = emailAddress;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        UpdateDate = DateTime.UtcNow;
    }
}
