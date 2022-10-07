namespace Memorabilia.Domain.Entities;

public class Brand : DomainEntity
{
    public Brand() { }

    public Brand(string name, string abbreviation) : base(name, abbreviation) { }
}
