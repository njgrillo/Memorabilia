namespace Memorabilia.Domain.Entities;

public class ForumCategory : Framework.Library.Domain.Entity.DomainEntity
{
    public ForumCategory() { }

    public ForumCategory(string abbreviation, 
                         bool canBeSportRelated, 
                         string name)
    {
        Abbreviation = abbreviation;
        CanBeSportRelated = canBeSportRelated;
        Name = name;        
    }

    public string Abbreviation { get; set; }

    public bool CanBeSportRelated { get; set; }

    public string Name { get; set; }

    public void Set(string abbreviation,
                    bool canBeSportRelated,
                    string name)
    {        
        Abbreviation = abbreviation;
        CanBeSportRelated = canBeSportRelated;
        Name = name;
    }
}
