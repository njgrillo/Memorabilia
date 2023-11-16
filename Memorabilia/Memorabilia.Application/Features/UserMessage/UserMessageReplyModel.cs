namespace Memorabilia.Application.Features.UserMessage;

public class UserMessageReplyModel
{
    private readonly Entity.UserMessageReply _userMessageReply;

    public UserMessageReplyModel() { }

    public UserMessageReplyModel(Entity.UserMessageReply userMessageReply)
    {
        _userMessageReply = userMessageReply;

        Images = _userMessageReply.Images
                                  .Select(image => new UserMessageReplyImageModel(image))
                                  .ToArray();  
    }

    public int CreatedByUserId
        => _userMessageReply.CreatedByUserId;

    public DateTime CreatedDate
        => _userMessageReply.CreatedDate;

    public bool DisplayDetails { get; set; }

    public int Id 
        => _userMessageReply.Id;

    public UserMessageReplyImageModel[] Images { get; set; }
        = [];

    public string Message
        => _userMessageReply.Message;

    public string ReceiverUserName
        => _userMessageReply.ReceiverUser.Username;

    public int ReceiverUserId
        => _userMessageReply.ReceiverUserId;

    public Entity.User SenderUser
        => _userMessageReply.SenderUser;

    public int SenderUserId
        => _userMessageReply.SenderUserId;

    public string SenderUserName
        => _userMessageReply.SenderUser.Username;

    public int UserMessageId
        => _userMessageReply.UserMessageId;

    public int UserMessageStatusId
        => _userMessageReply.UserMessageStatusId;
}
