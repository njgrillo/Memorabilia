namespace Memorabilia.Application.Features.Transaction;

public class MemorabiliaTransactionTradeModel
{
    private readonly Entity.MemorabiliaTransactionTrade _trade;

    public MemorabiliaTransactionTradeModel() { }

    public MemorabiliaTransactionTradeModel(Entity.MemorabiliaTransactionTrade trade)
    {
        _trade = trade;
    }

    public decimal? CashIncludedAmount
        => _trade.CashIncludedAmount;

    public Constant.TransactionTradeType CashIncludedType
        => Constant.TransactionTradeType.Find(CashIncludedTypeId ?? 0);

    public string CashIncludedTypeIcon
        => CashIncludedType == Constant.TransactionTradeType.Received
            ? MudBlazor.Icons.Material.Filled.ArrowBack
            : MudBlazor.Icons.Material.Filled.ArrowForward;

    public int? CashIncludedTypeId
        => _trade.CashIncludedTypeId;

    public string CashIncludedTypeName
        => CashIncludedType?.Name ?? string.Empty;

    public int Id
        => _trade.Id;

    public Entity.Memorabilia Memorabilia
        => _trade.Memorabilia;

    public int MemorabiliaId
        => _trade.MemorabiliaId;

    public int MemorabiliaTransactionId
        => _trade.MemorabiliaTransactionId;

    public DateTime? TransactionDate
        => _trade.Transaction.TransactionDate;

    public Constant.TransactionTradeType TransactionTradeType
        => Constant.TransactionTradeType.Find(TransactionTradeTypeId);

    public string TransactionTradeTypeIcon
        => TransactionTradeType == Constant.TransactionTradeType.Received
            ? MudBlazor.Icons.Material.Filled.ArrowBack
            : MudBlazor.Icons.Material.Filled.ArrowForward;

    public int TransactionTradeTypeId
        => _trade.TransactionTradeTypeId;

    public string TransactionTradeTypeName
        => TransactionTradeType?.Name ?? string.Empty;

    public Constant.TransactionType TransactionType
        => Constant.TransactionType.Find(_trade.Transaction.TransactionTypeId);
}
