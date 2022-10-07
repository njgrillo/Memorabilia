namespace Memorabilia.Domain.Entities;

public class MagazineType : DomainEntity
{
    public MagazineType() { }

    public MagazineType(string name, string abbreviation) : base(name, abbreviation) { }
}
