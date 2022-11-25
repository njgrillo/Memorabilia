namespace Memorabilia.Domain.Constants;

public sealed class Size : DomainItemConstant
{
    public static readonly Size EightByTen = new(11, "8x10", string.Empty);
    public static readonly Size ElevenByFourteen = new(12, "11x14", string.Empty);
    public static readonly Size ExtraExtraLarge = new(1018, "Extra Extra Large", "XXL");
    public static readonly Size ExtraLarge = new(10, "Extra Large", "XL");
    public static readonly Size FiftyFour = new(1017, "54", string.Empty);
    public static readonly Size FiftySix = new(1019, "56", "XXXL");
    public static readonly Size FiftyTwo = new(1016, "52", string.Empty);
    public static readonly Size FortyFour = new(1015, "44", string.Empty);
    public static readonly Size Full = new(2, "Full Size", string.Empty);
    public static readonly Size Large = new(3, "Large", "L");
    public static readonly Size Medium = new(9, "Medium", "M");
    public static readonly Size Mini = new(1, "Mini", string.Empty);
    public static readonly Size None = new(8, "None", string.Empty);
    public static readonly Size Other = new(7, "Other", string.Empty);
    public static readonly Size Oversized = new(6, "Oversized", string.Empty);
    public static readonly Size SixteenByTwenty = new(13, "16x20", string.Empty);
    public static readonly Size Small = new(4, "Small", "S");
    public static readonly Size Standard = new(5, "Standard", string.Empty);
    public static readonly Size ThreeByFive = new(15, "3x5", string.Empty);
    public static readonly Size TwentyByThirty = new(14, "20x30", string.Empty);
    public static readonly Size Unknown = new(1022, "Unknown", string.Empty);

    public static readonly Size[] All =
    {
        EightByTen,
        ElevenByFourteen,
        ExtraExtraLarge,
        ExtraLarge,
        FiftyFour,
        FiftySix,
        FiftyTwo,
        FortyFour,
        Full,
        Large,
        Medium,
        Mini,
        None,
        Other,
        Oversized,
        SixteenByTwenty,
        Small,
        Standard,
        ThreeByFive,
        TwentyByThirty,
        Unknown
    };

    private Size(int id, string name, string abbreviation) : base(id, name, abbreviation) { }

    public static Size Find(int id)
    {
        return All.SingleOrDefault(size => size.Id == id);
    }

    public static Size Find(string name)
    {
        return All.SingleOrDefault(size => size.Name == name);
    }
}
