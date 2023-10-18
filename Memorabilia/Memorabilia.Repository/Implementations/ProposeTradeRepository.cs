namespace Memorabilia.Repository.Implementations;

public class ProposeTradeRepository
    : MemorabiliaRepository<ProposeTrade>, IProposeTradeRepository
{
    public ProposeTradeRepository(MemorabiliaContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }

    public async Task<ProposeTrade[]> GetAll(int userId)
        => await Items.Where(proposeTrade => proposeTrade.TradeCreatorUserId == userId
                                          || proposeTrade.TradePartnerUserId == userId)
                      .ToArrayAsync();

    public async Task<ProposeTrade[]> GetAllAccepted(int userId)
        => await Items.Where(proposeTrade => (proposeTrade.TradeCreatorUserId == userId || proposeTrade.TradePartnerUserId == userId)
                                          && proposeTrade.ProposeTradeStatusTypeId == Constant.ProposeTradeStatusType.Accepted.Id)
                      .ToArrayAsync();

    public async Task<ProposeTrade[]> GetAllExpired()
        => await Items.Where(proposeTrade => proposeTrade.ExpirationDate <= DateTime.UtcNow
                                          && proposeTrade.ProposeTradeStatusTypeId == Constant.ProposeTradeStatusType.Pending.Id)
                      .ToArrayAsync();

    public async Task<ProposeTrade[]> GetAllOpen(int? userId = null)
        => await Items.Where(proposeTrade => (userId == null || proposeTrade.TradeCreatorUserId == userId.Value || proposeTrade.TradePartnerUserId == userId.Value)
                                          && proposeTrade.ProposeTradeStatusTypeId == Constant.ProposeTradeStatusType.Pending.Id)
                      .ToArrayAsync();
}
