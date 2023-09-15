namespace Memorabilia.Repository.Implementations;

public class OfferRepository
    : MemorabiliaRepository<Entity.Offer>, IOfferRepository
{
    public OfferRepository(MemorabiliaContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }

    public async Task<Entity.Offer[]> GetAll(int userId)
        => await Items.Where(offer => offer.BuyerUserId == userId
                                   || offer.SellerUserId == userId)
                      .ToArrayAsync();

    public async Task<Entity.Offer[]> GetAllAccepted(int userId)
        => await Items.Where(offer => (offer.BuyerUserId == userId || offer.SellerUserId == userId)
                                   && offer.OfferStatusTypeId == Constant.OfferStatusType.Accepted.Id)
                      .ToArrayAsync();

    public async Task<Entity.Offer[]> GetAllExpired()
        => await Items.Where(offer => offer.ExpirationDate <= DateTime.UtcNow
                                   && offer.OfferStatusTypeId == Constant.OfferStatusType.Pending.Id)
                      .ToArrayAsync();

    public async Task<Entity.Offer[]> GetAllOpen(int? userId = null)
        => await Items.Where(offer => (userId == null || offer.BuyerUserId == userId.Value || offer.SellerUserId == userId.Value)
                                   && offer.OfferStatusTypeId == Constant.OfferStatusType.Pending.Id)
                      .ToArrayAsync();
}
