namespace Memorabilia.Domain.Entities;

public class ForumEntryImage : Entity
{
    public ForumEntryImage() { }

    public ForumEntryImage(int forumEntryId,
                           string imageFileName)
    {
        ForumEntryId = forumEntryId;
        ImageFileName = imageFileName;   
    }

    public int ForumEntryId { get; set; }

    public string ImageFileName { get; set; }
}
