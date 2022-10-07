namespace Memorabilia.Domain.Entities;

public class DashboardItem : Framework.Library.Domain.Entity.DomainEntity
{
    public DashboardItem() { }

    public DashboardItem(string name, string description)
    {
        Description = description;
        Name = name;
    }

    public string Description { get; private set; }

    public string Name { get; private set; }

    public void Set(string name, string description)
    {
        Description = description;
        Name = name;
    }
}
