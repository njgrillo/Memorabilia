namespace Memorabilia.Domain.Constants;

public sealed class SaleFilter : Filter<SaleFilter>
{
    public static readonly SaleFilter None = new("None");
    public static readonly SaleFilter ForSale = new("For Sale");
    public static readonly SaleFilter NotForSale = new("Not For Sale");

    private SaleFilter(string name)
        : base(name) { }

    public static readonly SaleFilter[] All =
    [
        None,
        ForSale,
        NotForSale
    ];

    public static readonly SaleFilter[] FilterItems =
    [
        ForSale,
        NotForSale
    ];
}
