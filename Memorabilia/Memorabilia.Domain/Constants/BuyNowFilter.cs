namespace Memorabilia.Domain.Constants;

public sealed class BuyNowFilter : Filter<BuyNowFilter>
{
    public static readonly BuyNowFilter None = new("None");
    public static readonly BuyNowFilter BuyNow = new("Is Buy Now");
    public static readonly BuyNowFilter IsNotBuyNow = new("Is Not Buy Now");

    private BuyNowFilter(string name)
        : base(name) { }

    public static readonly BuyNowFilter[] All =
    [
        None,
        BuyNow,
        IsNotBuyNow
    ];

    public static readonly BuyNowFilter[] FilterItems =
    [
        BuyNow,
        IsNotBuyNow
    ];
}
