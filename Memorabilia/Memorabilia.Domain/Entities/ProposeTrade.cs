namespace Memorabilia.Domain.Entities;

public class ProposeTrade : Framework.Library.Domain.Entity.DomainEntity
{
    public ProposeTrade() { }

    public ProposeTrade(decimal? amountToReceive, 
                        decimal? amountToSend, 
                        DateTime expirationDate, 
                        DateTime proposedDate, 
                        int proposeTradeStatusTypeId,
                        int receiverUserId,
                        int senderUserId)
    {
        AmountToReceive = amountToReceive;
        AmountToSend = amountToSend;
        ExpirationDate = expirationDate;
        ProposedDate = proposedDate;
        ProposeTradeStatusTypeId = proposeTradeStatusTypeId;
        ReceiverUserId = receiverUserId;
        SenderUserId = senderUserId;
    }

    public decimal? AmountToReceive { get; set; }

    public decimal? AmountToSend { get; set; }

    public DateTime ExpirationDate { get; set; }

    public virtual List<ProposeTradeMemorabilia> Memorabilia { get; set; }
        = new();

    public DateTime ProposedDate { get; set; }

    public int ProposeTradeStatusTypeId { get; set; }

    public virtual User ReceiverUser { get; private set; }

    public int ReceiverUserId { get; private set; }

    public virtual User SenderUser { get; private set; }

    public int SenderUserId { get; private set; }

    public void AddMemorabilia(int memorabiliaId, int proposeTradeMemorabiliaTypeId)
    {
        Memorabilia.Add(new ProposeTradeMemorabilia(memorabiliaId, Id, proposeTradeMemorabiliaTypeId));
    }

    public void Set(decimal? amountToReceive,
                    decimal? amountToSend,
                    DateTime expirationDate,
                    DateTime proposedDate,
                    int proposeTradeStatusTypeId)
    {
        AmountToReceive = amountToReceive;
        AmountToSend = amountToSend;
        ExpirationDate = expirationDate;
        ProposedDate = proposedDate;
        ProposeTradeStatusTypeId = proposeTradeStatusTypeId;
    }    

    public void SetStatus(Constant.ProposeTradeStatusType proposeTradeStatusType)
    {
        ProposeTradeStatusTypeId = proposeTradeStatusType.Id;
    }
}
