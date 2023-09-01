namespace Memorabilia.Application.Features.Transaction;

public class MemorabiliaTransactionSaleModel
{
    private readonly Entity.MemorabiliaTransactionSale _sale;

    public MemorabiliaTransactionSaleModel() { }

    public MemorabiliaTransactionSaleModel(Entity.MemorabiliaTransactionSale Sale)
    {
        _sale = Sale;
    }

    public int Id
        => _sale.Id;

    public Entity.Memorabilia Memorabilia
        => _sale.Memorabilia;

    public int MemorabiliaId
        => _sale.MemorabiliaId;

    public int MemorabiliaTransactionId
        => _sale.MemorabiliaTransactionId;

    public decimal? SaleAmount
        => _sale.SaleAmount;

    public DateTime? TransactionDate
        => _sale.Transaction.TransactionDate;    
}
