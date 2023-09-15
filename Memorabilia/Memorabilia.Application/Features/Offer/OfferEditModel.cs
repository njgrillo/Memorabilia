namespace Memorabilia.Application.Features.Offer;

public class OfferEditModel : EditModel
{
	public OfferEditModel() { }

    public OfferEditModel(OfferModel model, int userId)
    {
        Id = model.Id;
        Amount = model.Amount;
        BuyerId = model.Buyer.Id;
        ExpirationDate = model.ExpirationDate;
        Memorabilia = model.Memorabilia;
        MemorabiliaId = model.MemorabiliaId;
        OfferDate = model.OfferDate;
        OfferStatusTypeId = model.OfferStatusTypeId;
        SellerId = model.Seller.Id;

        OfferPartnerEmail = userId == BuyerId
            ? model.Seller.EmailAddress
            : model.Buyer.EmailAddress;

        OfferPartnerName = userId == BuyerId
            ? model.Seller.Username
            : model.Buyer.Username;

        UserName = userId == BuyerId
            ? model.Buyer.Username
            : model.Seller.Username;
    }

    public OfferEditModel(Entity.User buyer, Entity.User seller, Entity.Memorabilia memorabilia)
    {
        BuyerId = buyer.Id;
        Memorabilia = new OfferMemorabiliaModel(memorabilia);
        MemorabiliaId = memorabilia.Id;
        OfferPartnerEmail = seller.EmailAddress;
        OfferPartnerName = seller.Username;
        OfferStatusTypeId = Constant.OfferStatusType.Pending.Id;
        SellerId = seller.Id;
        UserName = buyer.Username;
    }

    public OfferEditModel(Entity.Offer offer, int userId)
    {
        Id = offer.Id;
        Amount = offer.Amount;
        BuyerId = offer.BuyerUserId;        
        ExpirationDate = offer.ExpirationDate;  
        Memorabilia = new OfferMemorabiliaModel(offer.Memorabilia);
        MemorabiliaId = offer.MemorabiliaId;
        OfferDate = offer.OfferDate;
        OfferStatusTypeId = offer.OfferStatusTypeId;
        SellerId = offer.SellerUserId;

        OfferPartnerEmail = userId == BuyerId
            ? offer.SellerUser.EmailAddress
            : offer.BuyerUser.EmailAddress;

        OfferPartnerName = userId == BuyerId
            ? offer.SellerUser.Username
            : offer.BuyerUser.Username;

        UserName = userId == BuyerId
            ? offer.BuyerUser.Username
            : offer.SellerUser.Username;
    }

    public decimal? Amount { get; set; }

    public int BuyerId { get; set; }    

    public DateTime ExpirationDate { get; set; }

    public OfferMemorabiliaModel Memorabilia { get; set; }

    public int MemorabiliaId { get; set; }

    public DateTime OfferDate { get; set; }

    public string OfferPartnerEmail { get; set; }

    public string OfferPartnerName { get; set; }

    public int OfferStatusTypeId { get; set; }

    public int SellerId { get; set; }

    public string UserName { get; set; } 
}
