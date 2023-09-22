namespace Memorabilia.Application.Features.UserMessage;

public class UserMessageEditModel : EditModel
{
	public UserMessageEditModel() { }

	public UserMessageEditModel(Entity.UserMessage userMessage)
	{
        CreatedByUserId = userMessage.CreatedByUserId;
        CreatedDate = userMessage.CreatedDate;
        Id = userMessage.Id;
        ReceiverUserId = userMessage.ReceiverUserId;
        SenderUserId = userMessage.SenderUserId;
        Subject = userMessage.Subject;
	}

    public int CreatedByUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public string Message { get; set; }

    public UserModel ReceiverUser { get; set; }
        = new();

    public int ReceiverUserId { get; set; }

    public UserModel SenderUser { get; set; }
        = new();

    public int SenderUserId { get; set; }

    public string Subject { get; set; }
}
