namespace Memorabilia.Application.Features.ProposeTrade;

public class ProposeTradeModel
{
    private readonly Entity.ProposeTrade _proposeTrade;

    public ProposeTradeModel() { }

    public ProposeTradeModel(Entity.ProposeTrade proposeTrade, int userId)
    {
        _proposeTrade = proposeTrade;

        UserId = userId;
    }

    public decimal? AmountTradeCreatorToReceive 
        => _proposeTrade.AmountTradeCreatorToReceive;

    public decimal? AmountTradeCreatorToSend
        => _proposeTrade.AmountTradeCreatorToSend;

    public decimal? AmountToReceive
        => UserId == _proposeTrade.TradeCreatorUserId
            ? AmountTradeCreatorToReceive
            : AmountTradeCreatorToSend;

    public decimal? AmountToSend
        => UserId == _proposeTrade.TradeCreatorUserId 
            ? AmountTradeCreatorToSend
            : AmountTradeCreatorToReceive;

    public bool CantAcceptCounterReject
        => _proposeTrade.Id > 0  &&
           _proposeTrade.ProposeTradeStatusTypeId == Constant.ProposeTradeStatusType.Pending.Id &&
           UserId == _proposeTrade.TradeCreatorUserId;

    public bool DisplayTradeDetails { get; set; }

    public DateTime ExpirationDate
        => _proposeTrade.ExpirationDate;

    public int Id
        => _proposeTrade.Id;    

    public bool IsTradeCreator
        => (_proposeTrade.TradeCreatorUser?.Id ?? 0) == UserId;

    public Entity.ProposeTradeMemorabilia[] Memorabilia
        => _proposeTrade.Memorabilia
                        .ToArray();

    public DateTime ProposedDate 
        => _proposeTrade.ProposedDate;

    public Constant.ProposeTradeStatusType ProposeTradeStatusType 
        => Constant.ProposeTradeStatusType.Find(ProposeTradeStatusTypeId);

    public int ProposeTradeStatusTypeId
        => _proposeTrade.ProposeTradeStatusTypeId;

    public string ProposeTradeStatusTypeName
        => ProposeTradeStatusType?.Name;

    public Entity.ProposeTradeMemorabilia[] ReceivingItems
        => _proposeTrade.Memorabilia
                        .Where(item => item.Memorabilia.User.Id != UserId)
                        .ToArray();

    public int ReceivingItemsCount
        => ReceivingItems.Length;

    public Entity.User TradeCreator
        => _proposeTrade.TradeCreatorUser;

    public Entity.User TradePartner
        => _proposeTrade.TradePartnerUser;

    public Entity.ProposeTradeMemorabilia[] SendingItems
        => _proposeTrade.Memorabilia
                        .Where(item => item.Memorabilia.User.Id == UserId)
                        .ToArray(); 

    public int SendingItemsCount
        => SendingItems.Length;

    public bool ShowActions
        => ProposeTradeStatusTypeId == Constant.ProposeTradeStatusType.Pending.Id;

    public string ToggleIcon { get; set; }
        = MudBlazor.Icons.Material.Filled.ExpandMore;

    public string TradePartnerEmail
        => (TradeCreator?.Id ?? 0) == UserId
            ? TradePartner?.EmailAddress
            : TradeCreator?.EmailAddress; 

    public string TradePartnerName
        => (TradeCreator?.Id ?? 0) == UserId
            ? TradePartner?.Username
            : TradeCreator?.Username; 

    public string UserEmail
        => (TradeCreator?.Id ?? 0) == UserId
            ? TradeCreator?.EmailAddress
            : TradePartner?.EmailAddress;

    public string UserName
        => (TradeCreator?.Id ?? 0) == UserId
            ? TradeCreator?.Username
            : TradePartner?.Username;

    public int UserId { get; private set; }
}
