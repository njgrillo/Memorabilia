namespace Memorabilia.Domain.Entities;

public class UserMessageReplyImage : Framework.Library.Domain.Entity.DomainEntity
{
    public UserMessageReplyImage() { }

    public UserMessageReplyImage(byte[] imageData,
                                 int userMessageReplyId)
    {
        ImageData = imageData;
        UserMessageReplyId = userMessageReplyId;
    }

    public byte[] ImageData { get; private set; }

    public virtual UserMessageReply UserMessageReply { get; private set; }

    public int UserMessageReplyId { get; private set; }
}
