namespace Memorabilia.Application.Features.Home;

public class AcceptedOfferModel
{
    private readonly Entity.Offer _offer;

    public AcceptedOfferModel() { }

    public AcceptedOfferModel(Entity.Offer offer, int userId)
    {
        _offer = offer;

        UserId = userId;
    }    

    public decimal Amount
        => _offer.Amount;

    public string BuyerName
        => _offer.BuyerUser.Username;

    public int Id
        => _offer.Id;

    public DateTime OfferDate
        => _offer.OfferDate;

    public Constant.OfferStatusType OfferStatusType
        => Constant.OfferStatusType.Find(OfferStatusTypeId);

    public int OfferStatusTypeId
        => _offer.OfferStatusTypeId;

    public string OfferStatusTypeName
        => OfferStatusType?.Name;

    public string SellerName
        => _offer.SellerUser.Username;

    public int UserId { get; private set; }
}
