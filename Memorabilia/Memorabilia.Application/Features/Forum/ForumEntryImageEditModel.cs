namespace Memorabilia.Application.Features.Forum;

public class ForumEntryImageEditModel : EditModel
{
    public ForumEntryImageEditModel() { }

    public ForumEntryImageEditModel(int forumEntryId, byte[] image)
    {
        ForumEntryId = forumEntryId;
        Image = image;  
    }

    public ForumEntryImageEditModel(Entity.ForumEntryImage forumEntryImage)
    {
        ForumEntryId = forumEntryImage.ForumEntryId;
        Id = forumEntryImage.Id;
        Image = forumEntryImage.ImageData;
    }

    public int ForumEntryId { get; set; }

    public byte[] Image { get; set; }

    public string ImageData
        => Image != null
            ? Encoding.UTF8.GetString(Image, 0, Image.Length)
            : string.Empty;
}
