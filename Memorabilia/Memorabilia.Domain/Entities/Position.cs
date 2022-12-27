namespace Memorabilia.Domain.Entities;

public class Position : Framework.Library.Domain.Entity.DomainEntity
{
    public Position() { }

    public Position(int sportId, string name, string abbreviation)
    {
        SportId = sportId;
        Name = name;
        Abbreviation = abbreviation;
    }

    public string Abbreviation { get; set; }

    public string Name { get; set; }

    public int SportId { get; set; }

    public void Set(int sportId, string name, string abbreviation)
    {
        SportId = sportId;
        Name = name;
        Abbreviation = abbreviation;
    }
}
