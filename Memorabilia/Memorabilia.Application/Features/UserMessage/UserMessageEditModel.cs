namespace Memorabilia.Application.Features.UserMessage;

public class UserMessageEditModel : EditModel
{
	public UserMessageEditModel() { }

    public UserMessageEditModel(string subject)
    {
        Subject = subject;
    }

	public UserMessageEditModel(Entity.UserMessage userMessage)
	{
        Id = userMessage.Id;
        Subject = userMessage.Subject;
        UserMessageStatusId = userMessage.UserMessageStatusId;
	}

    public UserMessageEditModel(Entity.UserMessage userMessage, Entity.User sender, Entity.User receiver)
    {
        Id = userMessage.Id;
        Subject = userMessage.Subject;
        UserMessageStatusId = userMessage.UserMessageStatusId;

        UserMessageReply.ReceiverUser = new UserModel(sender);
        UserMessageReply.SenderUser = new UserModel(receiver);
    }

    public string Subject { get; set; }

    public UserMessageReplyEditModel UserMessageReply { get; set; }
        = new();

    public int UserMessageStatusId { get; set; }
}
