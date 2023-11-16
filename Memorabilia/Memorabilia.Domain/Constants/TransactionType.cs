namespace Memorabilia.Domain.Constants;

public sealed class TransactionType : DomainItemConstant
{
    public static readonly TransactionType PartialTrade = new(3, "Partial Trade");
    public static readonly TransactionType Sale = new(1, "Sale");
    public static readonly TransactionType Trade = new(2, "Trade");    

    public static readonly TransactionType[] All =
    [
        PartialTrade,
        Sale, 
        Trade
    ];

    private TransactionType(int id, string name, string abbreviation = null)
        : base(id, name, abbreviation) { }

    public static TransactionType Find(int id)
        => All.SingleOrDefault(transactionType => transactionType.Id == id);
}
