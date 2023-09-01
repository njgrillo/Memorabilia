namespace Memorabilia.Application.Features.Transaction;

public class MemorabiliaTransactionTradeEditModel : EditModel
{
    public MemorabiliaTransactionTradeEditModel() { }

    public MemorabiliaTransactionTradeEditModel(Entity.MemorabiliaTransactionTrade trade)
    {
        CashIncludedAmount = trade.CashIncludedAmount;
        CashIncludedTypeId = trade.CashIncludedTypeId ?? 0;
        Id = trade.Id;
        Memorabilia = trade.Memorabilia;
        MemorabiliaId = trade.MemorabiliaId;
        MemorabiliaTransactionId = trade.MemorabiliaTransactionId;        
        TransactionTradeTypeId = trade.TransactionTradeTypeId;
        TransactionType = Constant.TransactionType.Find(trade.Transaction.TransactionTypeId);
    }

    public MemorabiliaTransactionTradeEditModel(MemorabiliaTransactionTradeModel model)
    {
        CashIncludedAmount = model.CashIncludedAmount;
        CashIncludedTypeId = model.CashIncludedTypeId ?? 0;
        Id = model.Id;
        Memorabilia = model.Memorabilia;
        MemorabiliaId = model.MemorabiliaId;
        MemorabiliaTransactionId = model.MemorabiliaTransactionId;
        TransactionTradeTypeId = model.TransactionTradeTypeId;
        TransactionType = model.TransactionType;
    }

    public decimal? CashIncludedAmount { get; set; }

    public Constant.TransactionTradeType CashIncludedType
        => Constant.TransactionTradeType.Find(CashIncludedTypeId);

    public int CashIncludedTypeId { get; set; }

    public string CashIncludedTypeName
        => CashIncludedType?.Name;

    public Entity.Memorabilia Memorabilia { get; set; }

    public int MemorabiliaId { get; set; }

    public int MemorabiliaTransactionId { get; set; }    

    public Constant.TransactionTradeType TransactionTradeType
        => Constant.TransactionTradeType.Find(TransactionTradeTypeId);    

    public int TransactionTradeTypeId { get; set; }

    public string TransactionTradeTypeName
        => TransactionTradeType?.Name;

    public Constant.TransactionType TransactionType { get; set; }

    public int UserId { get; set; }
}
