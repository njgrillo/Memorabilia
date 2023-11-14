namespace Memorabilia.Application.Features.Forum;

public class ForumEntryImageModel
{
    private readonly Entity.ForumEntryImage _forumEntryImage;

    public ForumEntryImageModel() { }

    public ForumEntryImageModel(Entity.ForumEntryImage forumEntryImage)
    {
        _forumEntryImage = forumEntryImage;
    }

    public int Id
        => _forumEntryImage.Id;

    public string ImageFileName
        => _forumEntryImage.ImageFileName;
}
