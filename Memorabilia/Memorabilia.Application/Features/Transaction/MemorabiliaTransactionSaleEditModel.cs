namespace Memorabilia.Application.Features.Transaction;

public class MemorabiliaTransactionSaleEditModel : EditModel
{
    public MemorabiliaTransactionSaleEditModel() { }

    public MemorabiliaTransactionSaleEditModel(Entity.MemorabiliaTransactionSale sale)
    {
        Id = sale.Id;
        Memorabilia = sale.Memorabilia;
        MemorabiliaId = sale.MemorabiliaId;
        MemorabiliaTransactionId = sale.MemorabiliaTransactionId;
        SaleAmount = sale.SaleAmount;
    }

    public MemorabiliaTransactionSaleEditModel(MemorabiliaTransactionSaleModel model)
    {
        Id = model.Id;
        Memorabilia = model.Memorabilia;
        MemorabiliaId = model.MemorabiliaId;
        MemorabiliaTransactionId = model.MemorabiliaTransactionId;
        SaleAmount = model.SaleAmount;
    }

    public Entity.Memorabilia Memorabilia { get; set; }

    public int MemorabiliaId { get; set; }

    public int MemorabiliaTransactionId { get; set; }

    public decimal? SaleAmount { get; set; }

    public int UserId { get; set; }
}
