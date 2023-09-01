namespace Memorabilia.Domain.Constants;

public sealed class TransactionTradeType : DomainItemConstant
{
    public static readonly TransactionTradeType Received = new(1, "Received");
    public static readonly TransactionTradeType Sent = new(2, "Sent");

    public static readonly TransactionTradeType[] All =
    {
        Received,
        Sent
    };

    private TransactionTradeType(int id, string name, string abbreviation = null)
        : base(id, name, abbreviation) { }

    public static TransactionTradeType Find(int id)
        => All.SingleOrDefault(transactionTradeType => transactionTradeType.Id == id);
}
