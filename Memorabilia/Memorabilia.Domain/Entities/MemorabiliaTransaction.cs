namespace Memorabilia.Domain.Entities;

public class MemorabiliaTransaction : DomainIdEntity
{
    public MemorabiliaTransaction() { }

    public MemorabiliaTransaction(int id,
                                  int transactionTypeId,
                                  DateTime? transactionDate,
                                  int userId) 
    { 
        Id = id;
        TransactionTypeId = transactionTypeId;
        TransactionDate = transactionDate;
        UserId = userId;
    }

    public MemorabiliaTransaction(MemorabiliaTransaction memorabiliaTransaction)
    {
        Id = memorabiliaTransaction.Id;
        TransactionTypeId = memorabiliaTransaction.TransactionTypeId;
        TransactionDate = memorabiliaTransaction.TransactionDate;
        UserId = memorabiliaTransaction.UserId;

        Sales = memorabiliaTransaction.Sales;
        Trades = memorabiliaTransaction.Trades;
    }

    public MemorabiliaTransaction(int transactionTypeId,
                                  DateTime? transactionDate,
                                  int userId)
    {
        TransactionTypeId = transactionTypeId;
        TransactionDate = transactionDate;
        UserId = userId;
    }

    public virtual List<MemorabiliaTransactionSale> Sales { get; set; }
        = new();

    public virtual List<MemorabiliaTransactionTrade> Trades { get; set; }
        = new();

    public DateTime? TransactionDate { get; private set; }

    public int TransactionTypeId { get; private set; }

    public int UserId { get; private set; }

    public void RemoveSales(params int[] ids)
    {
        if (ids == null || ids.Length == 0)
            return;

        Sales.RemoveAll(item => ids.Contains(item.Id));
    }

    public void RemoveTrades(params int[] ids)
    {
        if (ids == null || ids.Length == 0)
            return;

        Trades.RemoveAll(item => ids.Contains(item.Id));
    }

    public void Set(DateTime? transactionDate)
    {
        TransactionDate = transactionDate;
    }

    public void SetSale(int memorabiliaTransactionSaleId,
                        int memorabiliaId,
                        decimal saleAmount)
    {
        MemorabiliaTransactionSale sale = memorabiliaTransactionSaleId > 0
            ? Sales.SingleOrDefault(item => item.Id == memorabiliaTransactionSaleId)
            : Sales.SingleOrDefault(item => item.MemorabiliaId == memorabiliaId);

        if (sale == null)
        {
            Sales.Add(new MemorabiliaTransactionSale(memorabiliaId,
                                                     Id,
                                                     saleAmount));

            return;
        }

        sale.Set(memorabiliaId, saleAmount);
    }

    public void SetTrade(int memorabiliaTransactionTradeId,
                         int memorabiliaId,
                         int transactionTradeTypeId,
                         decimal? cashIncludedAmount = null,
                         int? cashIncludedTypeId = null)
    {
        MemorabiliaTransactionTrade trade = memorabiliaTransactionTradeId > 0
            ? Trades.SingleOrDefault(item => item.Id == memorabiliaTransactionTradeId)
            : Trades.SingleOrDefault(item => item.MemorabiliaId == memorabiliaId);

        if (trade == null)
        {
            Trades.Add(new MemorabiliaTransactionTrade(memorabiliaId,
                                                       Id,
                                                       transactionTradeTypeId,
                                                       cashIncludedAmount,
                                                       cashIncludedTypeId));

            return;
        }

        trade.Set(memorabiliaId, 
                  transactionTradeTypeId,
                  cashIncludedAmount,
                  cashIncludedTypeId);
    }
}
