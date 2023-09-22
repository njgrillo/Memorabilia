namespace Memorabilia.Application.Features.UserMessage;

public class UserMessageModel
{
	private readonly Entity.UserMessage _userMessage;

	public UserMessageModel() { }

	public UserMessageModel(Entity.UserMessage userMessage)
	{
        _userMessage = userMessage;
    }

	public int CreatedByUserId
		=> _userMessage.CreatedByUserId;

	public DateTime CreatedDate
		=> _userMessage.CreatedDate;

	public int Id
		=> _userMessage.Id;

	public string MessagePartnerUsername
		=> CreatedByUserId == SenderUserId
			? _userMessage.SenderUser.Username
			: _userMessage.ReceiverUser.Username;

	public int ReceiverUserId
		=> _userMessage.ReceiverUserId;

	public int SenderUserId
		=> _userMessage.SenderUserId;

	public string Subject
		=> _userMessage.Subject;
}
