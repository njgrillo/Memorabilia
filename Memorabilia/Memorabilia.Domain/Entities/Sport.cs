namespace Memorabilia.Domain.Entities;

public class Sport : Entity
{
    public Sport() { }

    public Sport(string name, string alternateName)
    {
        Name = name;
        AlternateName = alternateName;
        CreateDate = DateTime.UtcNow;
    }

    public string AlternateName { get; private set; }

    public DateTime CreateDate { get; private set; }

    public string ImageFileName { get; private set; }

    public DateTime? LastModifiedDate { get; private set; }

    public string Name { get; private set; }

    public void Set(string name, string alternateName)
    {
        Name = name;
        AlternateName = alternateName;
    }
}
