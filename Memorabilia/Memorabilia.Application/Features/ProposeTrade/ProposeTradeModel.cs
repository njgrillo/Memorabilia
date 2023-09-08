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

    public decimal? AmountToReceive 
        => _proposeTrade.AmountToReceive;

    public decimal? AmountToSend
        => _proposeTrade.AmountToSend;

    public bool DisplayTradeDetails { get; set; }

    public DateTime ExpirationDate
        => _proposeTrade.ExpirationDate;

    public int Id
        => _proposeTrade.Id;

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

    public int ReceivingItemsCount
        => _proposeTrade.Memorabilia
                        .Where(item => item.ProposeTradeMemorabiliaTypeId == Constant.ProposeTradeMemorabiliaType.Receive.Id)
                        .Count();

    public Entity.User ReceiverUser
        => _proposeTrade.ReceiverUser;

    public int ReceiverUserId
        => _proposeTrade.ReceiverUserId;

    public Entity.User SenderUser
        => _proposeTrade.SenderUser;

    public int SenderUserId
        => _proposeTrade.SenderUserId;

    public int SendingItemsCount
        => _proposeTrade.Memorabilia
                        .Where(item => item.ProposeTradeMemorabiliaTypeId == Constant.ProposeTradeMemorabiliaType.Send.Id)
                        .Count();

    public bool ShowActions
        => ProposeTradeStatusTypeId == Constant.ProposeTradeStatusType.Pending.Id
        || ProposeTradeStatusTypeId == Constant.ProposeTradeStatusType.Countered.Id;

    public string ToggleIcon { get; set; }
        = MudBlazor.Icons.Material.Filled.ExpandMore;

    public string TradePartnerName
        => ReceiverUserId == UserId
            ? $"{SenderUser.FirstName} {SenderUser.LastName}" //TODO: Replace w/Username
            : $"{ReceiverUser.FirstName} {ReceiverUser.LastName}"; //TODO: Replace w/Username

    public int UserId { get; private set; }
}
