namespace Memorabilia.Domain.Entities;

public class AwardType : DomainEntity
{
    public AwardType() { }

    public AwardType(string name, string abbreviation) : base(name, abbreviation) { }
}
