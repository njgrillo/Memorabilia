namespace Memorabilia.Domain.Entities;

public class TransactionType : DomainEntity
{
    public TransactionType() { }

    public TransactionType(string name, string abbreviation) : base(name, abbreviation) { }
}
