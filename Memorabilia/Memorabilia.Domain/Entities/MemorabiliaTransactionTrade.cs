namespace Memorabilia.Domain.Entities;

public class MemorabiliaTransactionTrade : Entity
{
    public MemorabiliaTransactionTrade() { }

    public MemorabiliaTransactionTrade(int memorabiliaId,
                                       int memorabiliaTransactionId,
                                       int transactionTradeTypeId,
                                       decimal? cashIncludedAmount = null,
                                       int? cashIncludedTypeId = null)
    {
        MemorabiliaId = memorabiliaId;
        MemorabiliaTransactionId = memorabiliaTransactionId;
        TransactionTradeTypeId = transactionTradeTypeId;
        CashIncludedAmount = cashIncludedAmount;
        CashIncludedTypeId = cashIncludedTypeId;
    }

    public decimal? CashIncludedAmount { get; private set; }

    public int? CashIncludedTypeId { get; private set; }

    public virtual Memorabilia Memorabilia { get; private set; }

    public int MemorabiliaId { get; private set; }

    public virtual MemorabiliaTransaction Transaction { get; private set; }

    public int MemorabiliaTransactionId { get; private set; }   

    public int TransactionTradeTypeId { get; private set; }

    public void Set(int memorabiliaId,
                    int transactionTradeTypeId,
                    decimal? cashIncludedAmount = null,
                    int? cashIncludedTypeId = null)
    {
        MemorabiliaId = memorabiliaId;
        TransactionTradeTypeId = transactionTradeTypeId;
        CashIncludedAmount = cashIncludedAmount;
        CashIncludedTypeId = cashIncludedTypeId;
    }
}
