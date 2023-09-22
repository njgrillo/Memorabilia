namespace Memorabilia.Application.Features.UserMessage;

public class UserMessageReplyImageModel
{
    private readonly Entity.UserMessageReplyImage _userMessageReplyImage;

    public UserMessageReplyImageModel() { }

    public UserMessageReplyImageModel(Entity.UserMessageReplyImage userMessageReplyImage)
    {
        _userMessageReplyImage = userMessageReplyImage;
    }

    public int Id
        => _userMessageReplyImage.Id;

    public byte[] ImageData
        => _userMessageReplyImage.ImageData;

    public int UserMessageReplyId
        => _userMessageReplyImage.UserMessageReplyId;
}
