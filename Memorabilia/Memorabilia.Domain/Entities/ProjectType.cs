namespace Memorabilia.Domain.Entities;

public class ProjectType : DomainEntity
{
    public ProjectType() { }

    public ProjectType(string name, string abbreviation) : base(name, abbreviation) { }
}
