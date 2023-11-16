namespace Memorabilia.Repository.Implementations;

public class ProposeTradeMemorabiliaRepository(MemorabiliaContext context, IMemoryCache memoryCache)
    : MemorabiliaRepository<ProposeTradeMemorabilia>(context, memoryCache), IProposeTradeMemorabiliaRepository
{
}
