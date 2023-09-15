namespace Memorabilia.Application.Features.Offer;

public class OfferModel
{
    private readonly Entity.Offer _offer;

    public OfferModel() { }

    public OfferModel(Entity.Offer offer, int userId)
    {
        _offer = offer;

        UserId = userId;

        Memorabilia = new OfferMemorabiliaModel(_offer.Memorabilia);
    }

    public decimal Amount
        => _offer.Amount;

    public Entity.User Buyer
        => _offer.BuyerUser;

    public bool CantAcceptCounterReject
        => _offer.Id > 0 &&
           _offer.OfferStatusTypeId == Constant.OfferStatusType.Pending.Id &&
           UserId == _offer.BuyerUserId;

    public DateTime ExpirationDate
        => _offer.ExpirationDate;

    public int Id
        => _offer.Id;

    public OfferMemorabiliaModel Memorabilia { get; set; }
        = new();

    public int MemorabiliaId
        => _offer.MemorabiliaId;

    public DateTime OfferDate
        => _offer.OfferDate;

    public int OfferStatusTypeId
        => _offer.OfferStatusTypeId;

    public string OfferStatusTypeName
        => Constant.OfferStatusType.Find(OfferStatusTypeId)?.Name;

    public Entity.User Seller
        => _offer.SellerUser;
    public bool ShowActions
        => OfferStatusTypeId == Constant.OfferStatusType.Pending.Id;

    public int UserId { get; set; }
}
