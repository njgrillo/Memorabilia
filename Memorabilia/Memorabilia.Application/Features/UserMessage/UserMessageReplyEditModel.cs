namespace Memorabilia.Application.Features.UserMessage;

public class UserMessageReplyEditModel : EditModel
{
	public UserMessageReplyEditModel() { }

	public UserMessageReplyEditModel(Entity.UserMessageReply userMessageReply)
	{
		CreatedByUserId = userMessageReply.CreatedByUserId;
		CreatedDate = userMessageReply.CreatedDate;
		Message = userMessageReply.Message;
		ReceiverUserId = userMessageReply.ReceiverUserId;
		SenderUserId = userMessageReply.SenderUserId;
		UserMessageId = userMessageReply.UserMessageId;
		UserMessageStatusId = userMessageReply.UserMessageStatusId;
	}

	public int CreatedByUserId { get; set; }

	public DateTime CreatedDate { get; set; }

	public List<UserMessageReplyImageEditModel> Images { get; set; }
		= new();

	public string Message { get; set; }

	public int ReceiverUserId { get; set; }

    public int SenderUserId { get; set; }

    public int UserMessageId { get; set; }

    public int UserMessageStatusId { get; set; }
}
