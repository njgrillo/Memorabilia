namespace Memorabilia.Application.Features.Home;

public class OpenProposedTradeModel
{
    private readonly Entity.ProposeTrade _proposeTrade;

    public OpenProposedTradeModel() { }

    public OpenProposedTradeModel(Entity.ProposeTrade proposeTrade, int userId)
    {
        _proposeTrade = proposeTrade;

        UserId = userId;
    }

    public DateTime ExpirationDate
        => _proposeTrade.ExpirationDate;

    public int Id
        => _proposeTrade.Id;

    public DateTime ProposedDate
        => _proposeTrade.ProposedDate;

    public Constant.ProposeTradeStatusType ProposeTradeStatusType
        => Constant.ProposeTradeStatusType.Find(ProposeTradeStatusTypeId);

    public int ProposeTradeStatusTypeId
        => _proposeTrade.ProposeTradeStatusTypeId;

    public string ProposeTradeStatusTypeName
        => ProposeTradeStatusType?.Name;

    public string TradePartnerName
        => _proposeTrade.TradeCreatorUserId == UserId
            ? _proposeTrade.TradePartnerUser.Username
            : _proposeTrade.TradeCreatorUser.Username;

    public int UserId { get; private set; }
}
