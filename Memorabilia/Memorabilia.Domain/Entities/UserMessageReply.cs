namespace Memorabilia.Domain.Entities;

public class UserMessageReply : Framework.Library.Domain.Entity.DomainEntity
{
    public UserMessageReply() { }

    public UserMessageReply(int createdByUserId, 
                            DateTime createdDate,
                            string message,   
                            int receiverUserId,
                            int senderUserId,
                            int userMessageId,
                            int userMessageStatusId)
    {
        CreatedByUserId = createdByUserId;
        CreatedDate = createdDate;
        Message = message;
        ReceiverUserId = receiverUserId;
        SenderUserId = senderUserId;
        UserMessageId = userMessageId;
        UserMessageStatusId = userMessageStatusId;
    }

    public virtual User CreatedByUser { get; private set; }

    public int CreatedByUserId { get; private set; }

    public DateTime CreatedDate { get; private set; }

    public virtual List<UserMessageReplyImage> Images { get; private set; }
        = new();

    public string Message { get; private set; }

    public virtual User ReceiverUser { get; private set; }

    public int ReceiverUserId { get; private set; }

    public virtual User SenderUser { get; private set; }

    public int SenderUserId { get; private set; }    

    public virtual UserMessage UserMessage { get; private set; }

    public int UserMessageId { get; private set; }

    public int UserMessageStatusId { get; private set; }

    public void AddImage(string imageFilename)
    {
        Images.Add(new UserMessageReplyImage(imageFilename, Id));
    }

    public void SetStatus(int userMessageStatusId)
    {
        UserMessageStatusId = userMessageStatusId;
    }
}
