namespace Memorabilia.Repository.Implementations;

public class ProposeTradeMemorabiliaRepository
        : MemorabiliaRepository<ProposeTradeMemorabilia>, IProposeTradeMemorabiliaRepository
{
    public ProposeTradeMemorabiliaRepository(MemorabiliaContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }
}
