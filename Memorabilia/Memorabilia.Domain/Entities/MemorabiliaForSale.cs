namespace Memorabilia.Domain.Entities;

public class MemorabiliaForSale : DomainIdEntity
{
    public MemorabiliaForSale() { }

    public MemorabiliaForSale(Memorabilia memorabilia) 
    {       
        AllowBestOffer = memorabilia.ForSale.AllowBestOffer;
        BuyNowPrice = memorabilia.ForSale.BuyNowPrice;
        Id = memorabilia.ForSale.Id;
        Memorabilia = memorabilia;
        MemorabiliaId = memorabilia.Id;
        MinimumOfferPrice = memorabilia.ForSale.MinimumOfferPrice;
    }

    public MemorabiliaForSale(int memorabiliaId, 
                              decimal? buyNowPrice, 
                              bool allowBestOffer, 
                              decimal? minimumOfferPrice)
    {
        MemorabiliaId = memorabiliaId;
        BuyNowPrice = buyNowPrice;
        AllowBestOffer = allowBestOffer;
        MinimumOfferPrice = minimumOfferPrice;
    }

    public bool AllowBestOffer { get; private set; }

    public decimal? BuyNowPrice { get; private set; }

    public virtual Memorabilia Memorabilia { get; private set; }

    public int MemorabiliaId { get; private set; }

    public decimal? MinimumOfferPrice { get; private set; }

    public void Set(decimal? buyNowPrice, bool allowBestOffer, decimal? minimumOfferPrice)
    {
        BuyNowPrice = buyNowPrice;
        AllowBestOffer = allowBestOffer;
        MinimumOfferPrice = minimumOfferPrice;
    }
}
