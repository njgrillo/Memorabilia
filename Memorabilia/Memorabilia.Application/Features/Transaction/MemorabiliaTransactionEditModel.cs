namespace Memorabilia.Application.Features.Transaction;

public class MemorabiliaTransactionEditModel : EditModel
{
    public MemorabiliaTransactionEditModel() { }

    public MemorabiliaTransactionEditModel(Entity.MemorabiliaTransaction transaction)
    {
        Id = transaction.Id;
        TransactionDate = transaction.TransactionDate;
        TransactionTypeId = transaction.TransactionTypeId;
    }

    public MemorabiliaTransactionEditModel(MemorabiliaTransactionModel model)
    {
        Id = model.MemorabiliaTransactionId;
        TransactionDate = model.TransactionDate;
        TransactionTypeId = model.TransactionTypeId;

        Sales = model.Sales
                     .Select(sale => new MemorabiliaTransactionSaleEditModel(sale))
                     .ToList();

        Trades = model.Trades
                      .Select(trade => new MemorabiliaTransactionTradeEditModel(trade))
                      .ToList();
    }

    public override string ItemTitle
        => "Transaction";

    public override string PageTitle
        => "Transaction";

    public override string RoutePrefix
        => "MyStuff/Transactions";

    public List<MemorabiliaTransactionSaleEditModel> Sales { get; set; }
        = new();

    public List<MemorabiliaTransactionTradeEditModel> Trades { get; set; }
        = new();

    public DateTime? TransactionDate { get; set; }

    public int TransactionTypeId { get; set; }

    public int UserId { get; set; }
}
