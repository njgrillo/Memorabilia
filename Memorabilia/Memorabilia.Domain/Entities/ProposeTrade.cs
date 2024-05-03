namespace Memorabilia.Domain.Entities;

public class ProposeTrade : Entity
{
    public ProposeTrade() { }

    public ProposeTrade(decimal? amountTradeCreatorToReceive, 
                        decimal? amountTradeCreatorToSend, 
                        DateTime expirationDate, 
                        DateTime proposedDate, 
                        int proposeTradeStatusTypeId,
                        int tradeCreatorUserId,
                        int tradePartnerUserId)
    {
        AmountTradeCreatorToReceive = amountTradeCreatorToReceive;
        AmountTradeCreatorToSend = amountTradeCreatorToSend;
        ExpirationDate = expirationDate;
        ProposedDate = proposedDate;
        ProposeTradeStatusTypeId = proposeTradeStatusTypeId;
        TradeCreatorUserId = tradeCreatorUserId;
        TradePartnerUserId = tradePartnerUserId;
    }

    [Precision(12, 2)]
    public decimal? AmountTradeCreatorToReceive { get; set; }

    [Precision(12, 2)]
    public decimal? AmountTradeCreatorToSend { get; set; }

    public DateTime ExpirationDate { get; set; }

    public virtual List<ProposeTradeMemorabilia> Memorabilia { get; set; }
        = [];

    public DateTime ProposedDate { get; set; }

    public int ProposeTradeStatusTypeId { get; set; }

    public virtual User TradeCreatorUser { get; private set; }

    public int TradeCreatorUserId { get; private set; }

    public virtual User TradePartnerUser { get; private set; }

    public int TradePartnerUserId { get; private set; }

    public void AddMemorabilia(int memorabiliaId, int userId)
    {
        Memorabilia.Add(new ProposeTradeMemorabilia(memorabiliaId, Id, userId));
    }

    public void RemoveMemorabilia(params int[] proposeTradeMemorabiliaIds)
    {
        Memorabilia.RemoveAll(item => proposeTradeMemorabiliaIds.Contains(item.Id));
    }   

    public void SetStatus(Constant.ProposeTradeStatusType proposeTradeStatusType)
    {
        ProposeTradeStatusTypeId = proposeTradeStatusType.Id;
    }
}
