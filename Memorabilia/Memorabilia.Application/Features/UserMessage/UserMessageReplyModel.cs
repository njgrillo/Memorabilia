namespace Memorabilia.Application.Features.UserMessage;

public class UserMessageReplyModel
{
    private readonly Entity.UserMessageReply _userMessageReply;

    public UserMessageReplyModel() { }

    public UserMessageReplyModel(Entity.UserMessageReply userMessageReply)
    {
        _userMessageReply = userMessageReply;
    }

    public int CreatedByUserId
        => _userMessageReply.CreatedByUserId;

    public DateTime CreatedDate
        => _userMessageReply.CreatedDate;

    public int Id 
        => _userMessageReply.Id;

    public string Message
        => _userMessageReply.Message;

    public int ReceiverUserId
        => _userMessageReply.ReceiverUserId;

    public int SenderUserId
        => _userMessageReply.SenderUserId;

    public int UserMessageId
        => _userMessageReply.UserMessageId;

    public int UserMessageStatusId
        => _userMessageReply.UserMessageStatusId;
}
