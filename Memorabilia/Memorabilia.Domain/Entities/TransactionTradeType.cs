namespace Memorabilia.Domain.Entities;

public class TransactionTradeType : DomainEntity
{
    public TransactionTradeType() { }

    public TransactionTradeType(string name, string abbreviation) : base(name, abbreviation) { }
}
