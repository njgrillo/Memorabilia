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

    public byte[] Image
        => _forumEntryImage.ImageData;

    public string ImageData
        => Image != null
            ? Encoding.UTF8.GetString(Image, 0, Image.Length)
            : string.Empty;
}
