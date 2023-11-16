namespace Memorabilia.Repository.Implementations;

public class MemorabiliaTransactionTradeRepository(MemorabiliaContext context, IMemoryCache memoryCache)
    : MemorabiliaRepository<MemorabiliaTransactionTrade>(context, memoryCache), IMemorabiliaTransactionTradeRepository
{
    private IQueryable<MemorabiliaTransactionTrade> Trades
        => Items.Include(sale => sale.Memorabilia)
                .Include(sale => sale.Transaction);

    public async Task<MemorabiliaTransactionTrade[]> GetAll(int memorabiliaTransactionId)
        => await Trades.Where(Trade => Trade.MemorabiliaTransactionId == memorabiliaTransactionId)
                       .ToArrayAsync();
}
