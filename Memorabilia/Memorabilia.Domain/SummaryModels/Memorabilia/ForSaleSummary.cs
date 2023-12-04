namespace Memorabilia.Domain.SummaryModels.Memorabilia;

public class ForSaleSummary(Entities.MemorabiliaForSale[] itemsForSale)
{
    public int BestOfferItems
        => itemsForSale.Where(item => item.AllowBestOffer).Count();

    public int BuyNowItems
        => itemsForSale.Where(item => item.BuyNowPrice.HasValue).Count();

    public decimal? BuyNowTotal
        => itemsForSale.Sum(item => item.BuyNowPrice);

    public int ItemsForSale
        => itemsForSale.Length;
}
