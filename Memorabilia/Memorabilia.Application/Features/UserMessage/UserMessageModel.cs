namespace Memorabilia.Application.Features.UserMessage;

public class UserMessageModel
{
	private readonly Entity.UserMessage _userMessage;

	public UserMessageModel() { }

	public UserMessageModel(Entity.UserMessage userMessage)
	{
        _userMessage = userMessage;

        Replies = _userMessage.Replies
                              .Select(reply => new UserMessageReplyModel(reply))
                              .ToArray();
    }

	public DateTime CreatedDate
		=> _userMessage.Replies
                       .FirstOrDefault()?
                       .CreatedDate ?? DateTime.UtcNow;

    public bool DisplayReplies { get; set; }

	public int Id
		=> _userMessage.Id;

    public string ReceiverUsername
        => _userMessage.Replies
                       .FirstOrDefault()?
                       .ReceiverUser?
                       .Username;

    public UserMessageReplyModel[] Replies { get; set; }
        = [];

    public string SenderUsername
        => _userMessage.Replies
                       .FirstOrDefault()?
                       .SenderUser?
					   .Username;

    public string Subject
		=> _userMessage.Subject;

    public string ToggleIcon { get; set; }
        = MudBlazor.Icons.Material.Filled.ExpandMore;

    public int UserMessageStatusId
        => _userMessage.UserMessageStatusId;
}
