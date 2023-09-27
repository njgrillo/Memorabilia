namespace Memorabilia.Domain.Constants;

public sealed class SocialMediaType : DomainItemConstant
{
    public static readonly SocialMediaType Instagram = new(3, "Instagram");
    public static readonly SocialMediaType Meta = new(1, "Meta");
    public static readonly SocialMediaType TikTok = new(6, "TikTok");
    public static readonly SocialMediaType Truth = new(5, "Truth");
    public static readonly SocialMediaType X = new(2, "X");
    public static readonly SocialMediaType YouTube = new(4, "YouTube");

    public static readonly SocialMediaType[] All =
    {
        Instagram,
        Meta,
        TikTok,
        Truth,
        X,
        YouTube
    };

    private SocialMediaType(int id, string name, string abbreviation = null)
        : base(id, name, abbreviation) { }

    public static SocialMediaType Find(int id)
        => All.SingleOrDefault(socialMediaType => socialMediaType.Id == id);
}
