namespace Memorabilia.Repository.Implementations;

public class MemorabiliaTransactionSaleRepository(MemorabiliaContext context, IMemoryCache memoryCache)
    : MemorabiliaRepository<MemorabiliaTransactionSale>(context, memoryCache), IMemorabiliaTransactionSaleRepository
{
    private IQueryable<MemorabiliaTransactionSale> Sales
        => Items.Include(sale => sale.Memorabilia)
                .Include(sale => sale.Transaction);

    public async Task<MemorabiliaTransactionSale[]> GetAll(int memorabiliaTransactionId)
        => await Sales.Where(sale => sale.MemorabiliaTransactionId == memorabiliaTransactionId)
                      .ToArrayAsync();
}
