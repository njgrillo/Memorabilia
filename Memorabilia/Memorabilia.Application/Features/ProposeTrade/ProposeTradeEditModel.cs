namespace Memorabilia.Application.Features.ProposeTrade;

public class ProposeTradeEditModel : EditModel
{
    public ProposeTradeEditModel() { }

    public ProposeTradeEditModel(Entity.ProposeTrade proposeTrade)
    {
        AmountToReceive = proposeTrade.AmountToReceive;
        AmountToSend = proposeTrade.AmountToSend;
        Id = proposeTrade.Id;
        ExpirationDate = proposeTrade.ExpirationDate;
        ProposedDate = proposeTrade.ProposedDate;
        ProposeTradeStatusTypeId = proposeTrade.ProposeTradeStatusTypeId;
        ReceiverUser = proposeTrade.ReceiverUser;
        SenderUser = proposeTrade.SenderUser;

        ReceiveItems = proposeTrade.Memorabilia
                                   .Where(proposeTradeMemorabilia => proposeTradeMemorabilia.ProposeTradeMemorabiliaTypeId == Constant.ProposeTradeMemorabiliaType.Receive.Id)
                                   .Select(proposeTradeMemorabilia => new ProposeTradeMemorabiliaEditModel(proposeTradeMemorabilia))
                                   .ToList();

        SendItems = proposeTrade.Memorabilia
                                .Where(proposeTradeMemorabilia => proposeTradeMemorabilia.ProposeTradeMemorabiliaTypeId == Constant.ProposeTradeMemorabiliaType.Send.Id)
                                .Select(proposeTradeMemorabilia => new ProposeTradeMemorabiliaEditModel(proposeTradeMemorabilia))
                                .ToList();
    }    

    public decimal? AmountToReceive { get; set; }

    public decimal? AmountToSend { get; set; }

    public DateTime ExpirationDate { get; set; }

    public DateTime ProposedDate { get; set; }

    public Constant.ProposeTradeStatusType ProposeTradeStatusType
        => Constant.ProposeTradeStatusType.Find(ProposeTradeStatusTypeId);

    public int ProposeTradeStatusTypeId { get; set; }
        = Constant.ProposeTradeStatusType.Pending.Id;

    public string ProposeTradeStatusTypeName
        => ProposeTradeStatusType?.Name;

    public List<ProposeTradeMemorabiliaEditModel> ReceiveItems { get; set; }
        = new();

    public int ReceiveItemsCount
        => ReceiveItems.Where(item => !item.IsDeleted)
                       .Count();

    public Entity.User ReceiverUser { get; set; }

    public List<ProposeTradeMemorabiliaEditModel> SendItems { get; set; }
        = new();

    public int SendItemsCount
        => SendItems.Where(item => !item.IsDeleted)
                    .Count();

    public Entity.User SenderUser { get; set; }
}
