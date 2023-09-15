namespace Memorabilia.Domain.Entities;

public class Offer : Framework.Library.Domain.Entity.DomainEntity
{
    public Offer() { }

    public Offer(decimal amount,
                 int buyerUserId, 
                 int offerStatusTypeId,
                 DateTime expirationDate,
                 int memorabiliaId,
                 DateTime offerDate,
                 int sellerUserId)
    {
        Amount = amount;
        BuyerUserId = buyerUserId;        
        ExpirationDate = expirationDate;
        MemorabiliaId = memorabiliaId;
        OfferDate = offerDate;
        OfferStatusTypeId = offerStatusTypeId;
        SellerUserId = sellerUserId;
    }

    public decimal Amount { get; set; }

    public virtual User BuyerUser { get; private set; }

    public int BuyerUserId { get; private set; }    

    public DateTime ExpirationDate { get; set; }

    public virtual Memorabilia Memorabilia { get; private set; }

    public int MemorabiliaId { get; set; }

    public DateTime OfferDate { get; set; }

    public int OfferStatusTypeId { get; set; }

    public virtual User SellerUser { get; private set; }

    public int SellerUserId { get; private set; }

    public void Set(decimal amount,
                    int offerStatusTypeId,
                    DateTime expirationDate,
                    DateTime offerDate)
    {
        Amount = amount;
        OfferStatusTypeId = offerStatusTypeId;
        ExpirationDate = expirationDate;
        OfferDate = offerDate;
    }

    public void SetStatus(Constant.OfferStatusType offerStatusType)
    {
        OfferStatusTypeId = offerStatusType.Id;
    }
}
