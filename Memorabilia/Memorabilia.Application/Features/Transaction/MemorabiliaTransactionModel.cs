using System.Diagnostics;
using static MudBlazor.Colors;

namespace Memorabilia.Application.Features.Transaction;

public class MemorabiliaTransactionModel
{
    private readonly Entity.MemorabiliaTransaction _memorabiliaTransaction;

    public MemorabiliaTransactionModel() { }

    public MemorabiliaTransactionModel(Entity.MemorabiliaTransaction memorabiliaTransaction)
    {
        _memorabiliaTransaction = memorabiliaTransaction;

        Sales = memorabiliaTransaction.Sales
                                      .Select(sale => new MemorabiliaTransactionSaleModel(sale))
                                      .ToArray();

        Trades = memorabiliaTransaction.Trades
                                       .Select(trade => new MemorabiliaTransactionTradeModel(trade))
                                       .ToArray();
    }

    public bool DisplayDetails { get; set; }

    public int MemorabiliaTransactionId
        => _memorabiliaTransaction.Id;

    public MemorabiliaTransactionSaleModel[] Sales
        = Array.Empty<MemorabiliaTransactionSaleModel>();

    public string ToggleIcon { get; set; }
        = MudBlazor.Icons.Material.Filled.ExpandMore;

    public decimal TotalAmountReceived
        => Trades.Where(trade => (trade.CashIncludedTypeId ?? 0) == Constant.TransactionTradeType.Received.Id)
                 .Sum(trade => trade.CashIncludedAmount ?? 0);

    public decimal TotalAmountSent
        => Trades.Where(trade => (trade.CashIncludedTypeId ?? 0) == Constant.TransactionTradeType.Sent.Id)
                 .Sum(trade => trade.CashIncludedAmount ?? 0);

    public int TotalItemsReceivedCount
        => Trades.Count(trade => trade.TransactionTradeTypeId == Constant.TransactionTradeType.Received.Id);

    public int TotalItemsSentCount
        => Trades.Count(trade => trade.TransactionTradeTypeId == Constant.TransactionTradeType.Sent.Id);

    public MemorabiliaTransactionTradeModel[] Trades
        = Array.Empty<MemorabiliaTransactionTradeModel>();

    public DateTime? TransactionDate
        => _memorabiliaTransaction.TransactionDate;

    public int TransactionTypeId
        => _memorabiliaTransaction.TransactionTypeId;

    public string TransactionTypeName
        => Constant.TransactionType.Find(TransactionTypeId)?.Name;
}
