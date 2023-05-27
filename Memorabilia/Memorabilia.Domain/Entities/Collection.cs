namespace Memorabilia.Domain.Entities;

public class Collection : Framework.Library.Domain.Entity.DomainEntity
{
    public Collection() { }

    public Collection(string name,
        string description,
        int userId)
    {
        Name = name;
        Description = description;
        UserId = userId;
    }

    public string Description { get; set; }

    public virtual List<CollectionMemorabilia> Memorabilia { get; set; }

    public string Name { get; set; }

    public int UserId { get; set; }

    public void Set(string name,
        string description)
    {
        Name = name;
        Description = description;
    }
}
