namespace Memorabilia.Application.Features.Offer;

public class OffersModel : Model
{
    public OffersModel() { }

    public OffersModel(IEnumerable<Entity.Offer> offers, int userId)
    {
        Offers = offers.Select(offer => new OfferModel(offer, userId))
                       .ToArray();
    }

    public OfferModel[] CompletedOffers
        => Offers.Where(offer => offer.OfferStatusTypeId == Constant.OfferStatusType.Accepted.Id
                              || offer.OfferStatusTypeId == Constant.OfferStatusType.Canceled.Id
                              || offer.OfferStatusTypeId == Constant.OfferStatusType.Countered.Id
                              || offer.OfferStatusTypeId == Constant.OfferStatusType.Expired.Id
                              || offer.OfferStatusTypeId == Constant.OfferStatusType.Rejected.Id)
                 .ToArray();

    public int CompletedOffersCount
        => CompletedOffers.Length;

    public override string ItemTitle
        => "Offer";

    public OfferModel[] Offers { get; set; }
        = [];

    public OfferModel[] OpenOffers
        => Offers.Where(offer => offer.OfferStatusTypeId == Constant.OfferStatusType.Pending.Id)
                 .ToArray();

    public int OpenOffersCount
     => OpenOffers.Length;

    public override string PageTitle
        => "Offers";
}
