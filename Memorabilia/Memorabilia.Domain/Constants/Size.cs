namespace Memorabilia.Domain.Constants;

public sealed class Size : DomainItemConstant
{
    public static readonly Size Eight = new(1027, "8");
    public static readonly Size EightByTen = new(11, "8x10");
    public static readonly Size Eleven = new(1031, "11");
    public static readonly Size ElevenByFourteen = new(12, "11x14");
    public static readonly Size ElevenHalf = new(1032, "11.5");
    public static readonly Size ExtraExtraLarge = new(1018, "Extra Extra Large", "XXL");
    public static readonly Size ExtraLarge = new(10, "Extra Large", "XL");
    public static readonly Size Fifty = new(1023, "50");
    public static readonly Size FiftyEight = new(1026, "58");
    public static readonly Size FiftyFour = new(1017, "54");
    public static readonly Size FiftySix = new(1019, "56", "XXXL");
    public static readonly Size FiftyTwo = new(1016, "52");
    public static readonly Size FortyEight = new(1025, "48");
    public static readonly Size FortyFour = new(1015, "44");
    public static readonly Size Full = new(2, "Full Size");
    public static readonly Size Gumball = new(1035, "Gumball");
    public static readonly Size Large = new(3, "Large", "L");
    public static readonly Size Medium = new(9, "Medium", "M");
    public static readonly Size Micro = new(1034, "Micro");
    public static readonly Size Mini = new(1, "Mini");    
    public static readonly Size Nine = new(1028, "9");
    public static readonly Size None = new(8, "None");
    public static readonly Size Other = new(7, "Other");
    public static readonly Size Oversized = new(6, "Oversized");
    public static readonly Size SixteenByTwenty = new(13, "16x20");
    public static readonly Size Sixty = new(1024, "60");
    public static readonly Size Small = new(4, "Small", "S");
    public static readonly Size Standard = new(5, "Standard");
    public static readonly Size Ten = new(1029, "10");
    public static readonly Size TenHalf = new(1030, "10.5");
    public static readonly Size ThreeByFive = new(15, "3x5");
    public static readonly Size Twelve = new(1033, "12");
    public static readonly Size TwentyByThirty = new(14, "20x30");
    public static readonly Size Unknown = new(1022, "Unknown");

    public static readonly Size[] All =
    {
        Eight,
        EightByTen,
        Eleven,
        ElevenByFourteen,
        ElevenHalf,
        ExtraExtraLarge,
        ExtraLarge,
        Fifty,
        FiftyEight,
        FiftyFour,
        FiftySix,
        FiftyTwo,
        FortyEight,
        FortyFour,
        Full,
        Gumball,
        Large,
        Medium,
        Micro,
        Mini,
        Nine,
        None,
        Other,
        Oversized,
        SixteenByTwenty,
        Sixty,
        Small,
        Standard,
        Ten,
        TenHalf,
        ThreeByFive,
        Twelve,
        TwentyByThirty,
        Unknown
    };

    private Size(int id, string name, string abbreviation = null) 
        : base(id, name, abbreviation) { }

    public static Size Find(int id)
        => All.SingleOrDefault(size => size.Id == id);

    public static Size Find(string name)
        => All.SingleOrDefault(size => size.Name == name);
}
