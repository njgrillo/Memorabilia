namespace Memorabilia.Domain.Entities;

public class UserMessage : Framework.Library.Domain.Entity.DomainEntity
{
    public UserMessage() { }

    public UserMessage(int createdByUserId,
                       DateTime createdDate,
                       int id,
                       int receiverUserId,
                       int senderUserId,
                       string subject)
    {
        CreatedByUserId = createdByUserId;
        CreatedDate = createdDate;
        Id = id;
        ReceiverUserId = receiverUserId;
        SenderUserId = senderUserId;
        Subject = subject;
    }

    public UserMessage(int createdByUserId, 
                       DateTime createdDate,
                       int receiverUserId,
                       int senderUserId,
                       string subject)
    {
        CreatedByUserId = createdByUserId;
        CreatedDate = createdDate;
        ReceiverUserId = receiverUserId;
        SenderUserId = senderUserId;
        Subject = subject;
    }

    public virtual User CreatedByUser { get; private set; }

    public int CreatedByUserId { get; private set; }

    public DateTime CreatedDate { get; private set; }    

    public virtual User ReceiverUser { get; private set; }

    public int ReceiverUserId { get; private set; }

    public virtual List<UserMessageReply> Replies { get; private set; }
        = new();

    public virtual User SenderUser { get; private set; }

    public int SenderUserId { get; private set; }

    public string Subject { get; private set; } 

    public void AddReply(int createdByUserId,
                         DateTime createdDate,
                         string message,
                         int receiverUserId,
                         int senderUserId,
                         int userMessageStatusId)
    {
        Replies.Add(new UserMessageReply(createdByUserId,
                                         createdDate,
                                         message,
                                         receiverUserId,
                                         senderUserId,
                                         Id,
                                         userMessageStatusId));
    }
}
