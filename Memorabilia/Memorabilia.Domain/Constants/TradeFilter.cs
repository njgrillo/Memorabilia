namespace Memorabilia.Domain.Constants;

public sealed class TradeFilter : Filter<TradeFilter>
{
    public static readonly TradeFilter None = new("None");
    public static readonly TradeFilter ForTrade = new("Available For Trade");
    public static readonly TradeFilter NotForTrade = new("Not For Trade");

    private TradeFilter(string name)
        : base(name) { }

    public static readonly TradeFilter[] All =
    {
        None,
        ForTrade,
        NotForTrade
    };

    public static readonly TradeFilter[] FilterItems =
    {
        ForTrade,
        NotForTrade
    };
}
