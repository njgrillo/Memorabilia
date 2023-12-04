namespace Memorabilia.Application.Features.ForSale;

public class ForSaleSummaryModel : Model
{
    private readonly ForSaleSummary _items;

    public ForSaleSummaryModel() { }

    public ForSaleSummaryModel(ForSaleSummary items)
    {
        _items = items;
    }

    public int BestOfferItems
        => _items?.BestOfferItems ?? 0;

    public int BuyNowItems
        => _items?.BuyNowItems ?? 0;

    public decimal? BuyNowTotal
        => _items?.BuyNowTotal;

    public int ItemsForSale
        => _items?.ItemsForSale ?? 0;
}
