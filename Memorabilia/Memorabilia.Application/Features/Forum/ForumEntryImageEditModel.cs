namespace Memorabilia.Application.Features.Forum;

public class ForumEntryImageEditModel : EditModel
{
    public ForumEntryImageEditModel() { }

    public ForumEntryImageEditModel(int forumEntryId, string imageFileName)
    {
        ForumEntryId = forumEntryId;
        ImageFileName = imageFileName;  
    }

    public ForumEntryImageEditModel(Entity.ForumEntryImage forumEntryImage)
    {
        ForumEntryId = forumEntryImage.ForumEntryId;
        Id = forumEntryImage.Id;
        ImageFileName = forumEntryImage.ImageFileName;
    }

    public int ForumEntryId { get; set; }

    public string ImageFileName { get; set; }
}
