namespace Memorabilia.Domain.Entities;

public class UserMessageReplyImage : Entity
{
    public UserMessageReplyImage() { }

    public UserMessageReplyImage(string imageFileName,
                                 int userMessageReplyId)
    {
        FileName = imageFileName;
        UserMessageReplyId = userMessageReplyId;
    }

    public string FileName { get; private set; }

    public virtual UserMessageReply UserMessageReply { get; private set; }

    public int UserMessageReplyId { get; private set; }
}
