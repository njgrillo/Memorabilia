namespace Memorabilia.Application.Features.ProposeTrade;

public class ProposeTradeEditModel : EditModel
{
    public ProposeTradeEditModel() { }

    public ProposeTradeEditModel(Entity.User proposeTradeCreatorUser, 
                                 Entity.User proposeTradePartnerUser,
                                 Entity.Memorabilia receiveMemorabilia) 
    {
        ProposeTradeCreateUser = proposeTradeCreatorUser;
        ProposeTradePartnerUser = proposeTradePartnerUser;

        ReceiveItems.Add(new ProposeTradeMemorabiliaEditModel(receiveMemorabilia));

        UserId = ProposeTradeCreateUser.Id;
    }

    public ProposeTradeEditModel(int userId, Entity.ProposeTrade proposeTrade)
    {
        Id = proposeTrade.Id;
        ExpirationDate = proposeTrade.ExpirationDate;
        ProposedDate = proposeTrade.ProposedDate;
        ProposeTradeCreateUser = proposeTrade.TradeCreatorUser;
        ProposeTradePartnerUser = proposeTrade.TradePartnerUser;
        ProposeTradeStatusTypeId = proposeTrade.ProposeTradeStatusTypeId;
        UserId = userId;

        AmountToReceive = IsTradeCreator
            ? proposeTrade.AmountTradeCreatorToReceive
            : proposeTrade.AmountTradeCreatorToSend;

        AmountToSend = IsTradeCreator
            ? proposeTrade.AmountTradeCreatorToSend
            : proposeTrade.AmountTradeCreatorToReceive;

        ReceiveItems = proposeTrade.Memorabilia
                                   .Where(proposeTradeMemorabilia => UserId != proposeTradeMemorabilia.UserId)
                                   .Select(proposeTradeMemorabilia => new ProposeTradeMemorabiliaEditModel(proposeTradeMemorabilia))
                                   .ToList();

        SendItems = proposeTrade.Memorabilia
                                .Where(proposeTradeMemorabilia => UserId == proposeTradeMemorabilia.UserId)
                                .Select(proposeTradeMemorabilia => new ProposeTradeMemorabiliaEditModel(proposeTradeMemorabilia))
                                .ToList();
    }    

    public decimal? AmountToReceive { get; set; }

    public decimal? AmountToSend { get; set; }

    public DateTime ExpirationDate { get; set; }

    public bool IsTradeCreator
        => UserId == (ProposeTradeCreateUser?.Id ?? 0);

    public bool IsTradePartner
        => UserId == (ProposeTradePartnerUser?.Id ?? 0);    

    public DateTime ProposedDate { get; set; }

    public Entity.User ProposeTradeCreateUser { get; set; }

    public Entity.User ProposeTradePartnerUser { get; set; }

    public Constant.ProposeTradeStatusType ProposeTradeStatusType
        => Constant.ProposeTradeStatusType.Find(ProposeTradeStatusTypeId);

    public int ProposeTradeStatusTypeId { get; set; }
        = Constant.ProposeTradeStatusType.Pending.Id;

    public List<ProposeTradeMemorabiliaEditModel> ReceiveItems { get; set; }
        = new();

    public int ReceiveItemsCount
        => ReceiveItems.Where(item => !item.IsDeleted)
                       .Count();

    public List<ProposeTradeMemorabiliaEditModel> SendItems { get; set; }
        = new();

    public int SendItemsCount
        => SendItems.Where(item => !item.IsDeleted)
                    .Count();

    public string Title
    {
        get
        {
            if (UserId == 0)
                return string.Empty;

            if (IsTradeCreator)
            {
                if (ProposeTradeStatusType == Constant.ProposeTradeStatusType.Pending)
                    return $"Propose Trade to {TradePartnerName}";

                if (Constant.ProposeTradeStatusType.IsCompleted(ProposeTradeStatusType.Id))
                    return $"Proposed Trade to {TradePartnerName} has {(ProposeTradeStatusType != Constant.ProposeTradeStatusType.Expired ? "been " : "") + ProposeTradeStatusType.Name}";
            }

            if (ProposeTradeStatusType == Constant.ProposeTradeStatusType.Pending)
                return $"Proposed Trade from {TradePartnerName}";

            if (Constant.ProposeTradeStatusType.IsCompleted(ProposeTradeStatusType.Id))
                return $"Proposed Trade from {TradePartnerName} has {(ProposeTradeStatusType != Constant.ProposeTradeStatusType.Expired ? "been " : "") + ProposeTradeStatusType.Name}";

            return "Counter Offer";
        }
    }

    public string TradePartnerEmail
        => IsTradeCreator
            ? ProposeTradePartnerUser?.EmailAddress
            : ProposeTradeCreateUser?.EmailAddress;

    public string TradePartnerName
        => IsTradeCreator
            ? ProposeTradePartnerUser?.Username
            : ProposeTradeCreateUser?.Username;

    public int TradePartnerUserId
        => IsTradeCreator
            ? ProposeTradePartnerUser?.Id ?? 0
            : ProposeTradeCreateUser?.Id ?? 0;

    public string UserName
        => IsTradeCreator
            ? ProposeTradeCreateUser?.Username
            : ProposeTradePartnerUser?.Username;

    public int UserId { get; set; }

    public void SwitchCreatorAndPartner(int userId)
    {
        UserId = userId;

        Entity.User creator = ProposeTradeCreateUser;
        Entity.User partner = ProposeTradePartnerUser;

        ProposeTradeCreateUser = partner;
        ProposeTradePartnerUser = creator;
        
    }
}
