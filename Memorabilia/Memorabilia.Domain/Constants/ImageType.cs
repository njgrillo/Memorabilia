namespace Memorabilia.Domain.Constants;

public sealed class ImageType : DomainItemConstant
{
    public static readonly ImageType Primary = new(1, "Primary");
    public static readonly ImageType Secondary = new(2, "Secondary");

    public static readonly ImageType[] All =
    {
        Primary,
        Secondary
    };

    private ImageType(int id, string name) : base(id, name) { }

    public static ImageType Find(int id)
    {
        return All.SingleOrDefault(imageType => imageType.Id == id);
    }
}
