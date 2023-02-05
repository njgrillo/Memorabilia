namespace Memorabilia.Domain.Constants;

public sealed class ImageFilter : Filter<ImageFilter>
{
    public static readonly ImageFilter None = new("None");
    public static readonly ImageFilter NoImages = new("No Images(s)");
    public static readonly ImageFilter Images = new("Image(s)");

    private ImageFilter(string name) 
        : base(name) { }

    public static readonly ImageFilter[] All =
    {
        None,
        NoImages,
        Images
    };

    public static readonly ImageFilter[] FilterItems =
    {
        NoImages,
        Images
    };
}
