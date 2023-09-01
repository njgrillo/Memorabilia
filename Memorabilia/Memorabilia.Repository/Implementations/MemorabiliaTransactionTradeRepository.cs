namespace Memorabilia.Repository.Implementations;

public class MemorabiliaTransactionTradeRepository
    : MemorabiliaRepository<Entity.MemorabiliaTransactionTrade>, IMemorabiliaTransactionTradeRepository
{
    public MemorabiliaTransactionTradeRepository(MemorabiliaContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }

    private IQueryable<Entity.MemorabiliaTransactionTrade> Trades
        => Items.Include(sale => sale.Memorabilia)
                .Include(sale => sale.Transaction);

    public async Task<Entity.MemorabiliaTransactionTrade[]> GetAll(int memorabiliaTransactionId)
        => await Trades.Where(Trade => Trade.MemorabiliaTransactionId == memorabiliaTransactionId)
                       .ToArrayAsync();
}
