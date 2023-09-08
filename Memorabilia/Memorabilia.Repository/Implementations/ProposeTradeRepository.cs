namespace Memorabilia.Repository.Implementations;

public class ProposeTradeRepository
    : MemorabiliaRepository<Entity.ProposeTrade>, IProposeTradeRepository
{
    public ProposeTradeRepository(MemorabiliaContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }

    public async Task<Entity.ProposeTrade[]> GetAll(int userId)
        => await Items.Where(proposeTrade => proposeTrade.ReceiverUserId == userId
                                          || proposeTrade.SenderUserId == userId)
                      .ToArrayAsync();
}
