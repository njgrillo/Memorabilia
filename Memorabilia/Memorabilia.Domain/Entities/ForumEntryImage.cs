namespace Memorabilia.Domain.Entities;

public class ForumEntryImage : Framework.Library.Domain.Entity.DomainEntity
{
    public ForumEntryImage() { }

    public ForumEntryImage(int forumEntryId,
                           byte[] imageData)
    {
        ForumEntryId = forumEntryId;
        ImageData = imageData;   
    }

    public int ForumEntryId { get; set; }

    public byte[] ImageData { get; set; }
}
