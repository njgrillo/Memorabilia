namespace Memorabilia.Repository.Implementations;

public class MemorabiliaTransactionSaleRepository
    : MemorabiliaRepository<MemorabiliaTransactionSale>, IMemorabiliaTransactionSaleRepository
{
    public MemorabiliaTransactionSaleRepository(MemorabiliaContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }

    private IQueryable<MemorabiliaTransactionSale> Sales
        => Items.Include(sale => sale.Memorabilia)
                .Include(sale => sale.Transaction);

    public async Task<MemorabiliaTransactionSale[]> GetAll(int memorabiliaTransactionId)
        => await Sales.Where(sale => sale.MemorabiliaTransactionId == memorabiliaTransactionId)
                      .ToArrayAsync();
}
