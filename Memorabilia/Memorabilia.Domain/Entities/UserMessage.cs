namespace Memorabilia.Domain.Entities;

public class UserMessage : Framework.Library.Domain.Entity.DomainEntity
{
    public UserMessage() { }

    public UserMessage(int id,
                       string subject,
                       int userMessageStatusId)
    {
        Id = id;
        Subject = subject;
        UserMessageStatusId = userMessageStatusId;
    }

    public UserMessage(string subject,
                       int userMessageStatusId)
    {
        Subject = subject;
        UserMessageStatusId = userMessageStatusId;
    }

    public virtual List<UserMessageReply> Replies { get; private set; }
        = new();

    public string Subject { get; private set; } 

    public int UserMessageStatusId { get; private set; }

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

    public void SetStatus(int userMessageStatusId)
    {
        UserMessageStatusId = userMessageStatusId;  
    }
}
