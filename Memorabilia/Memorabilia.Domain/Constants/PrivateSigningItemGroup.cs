namespace Memorabilia.Domain.Constants;

public sealed class PrivateSigningItemGroup : DomainItemConstant
{
    public static readonly PrivateSigningItemGroup BallsFlats = new(1, "Balls & Flats");
    public static readonly PrivateSigningItemGroup Cards = new(2, "Cards");
    public static readonly PrivateSigningItemGroup Equipment = new(3, "Equipment");
    public static readonly PrivateSigningItemGroup Flats = new(4, "Flats");
    public static readonly PrivateSigningItemGroup FlatsUpToEleven = new(5, "Flats to 11x14");
    public static readonly PrivateSigningItemGroup FlatsUpToElevenIncludeBalls = new(6, "Flats to 11x14/Balls");
    public static readonly PrivateSigningItemGroup FlatsUpToSixteen = new(7, "Flats to 16x20");
    public static readonly PrivateSigningItemGroup FlatsUpToSixteenIncludeBalls = new(8, "Flats to 16x20/Balls");
    public static readonly PrivateSigningItemGroup LargeFlats = new(9, "Large Flats");
    public static readonly PrivateSigningItemGroup Other = new(10, "Other");
    public static readonly PrivateSigningItemGroup Premium = new(11, "Premium");

    public static readonly PrivateSigningItemGroup[] All =
    {
        BallsFlats,
        Cards,
        Equipment,
        Flats,
        FlatsUpToEleven,
        FlatsUpToElevenIncludeBalls,
        FlatsUpToSixteen,
        FlatsUpToSixteenIncludeBalls,
        LargeFlats,
        Other,
        Premium
    };

    private PrivateSigningItemGroup(int id, string name, string abbreviation = null)
        : base(id, name, abbreviation) { }

    public static PrivateSigningItemGroup Find(int id)
        => All.SingleOrDefault(privateSigningItemGroup => privateSigningItemGroup.Id == id);
}
