namespace Memorabilia.Repository.Implementations;

public class MemorabiliaTransactionTradeRepository
    : MemorabiliaRepository<MemorabiliaTransactionTrade>, IMemorabiliaTransactionTradeRepository
{
    public MemorabiliaTransactionTradeRepository(MemorabiliaContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }

    private IQueryable<MemorabiliaTransactionTrade> Trades
        => Items.Include(sale => sale.Memorabilia)
                .Include(sale => sale.Transaction);

    public async Task<MemorabiliaTransactionTrade[]> GetAll(int memorabiliaTransactionId)
        => await Trades.Where(Trade => Trade.MemorabiliaTransactionId == memorabiliaTransactionId)
                       .ToArrayAsync();
}
