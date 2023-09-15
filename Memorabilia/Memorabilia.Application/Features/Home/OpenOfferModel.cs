namespace Memorabilia.Application.Features.Home;

public class OpenOfferModel
{
    private readonly Entity.Offer _offer;

    public OpenOfferModel() { }

    public OpenOfferModel(Entity.Offer offer, int userId)
    {
        _offer = offer;

        UserId = userId;
    }

    public decimal Amount
        => _offer.Amount;

    public string BuyerName
        => _offer.BuyerUser.Username;

    public DateTime ExpirationDate
        => _offer.ExpirationDate;

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
