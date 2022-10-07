namespace Memorabilia.Domain.Entities;

public class PurchaseType : DomainEntity
{
    public PurchaseType() { }

    public PurchaseType(string name, string abbreviation) : base(name, abbreviation) { }
}
