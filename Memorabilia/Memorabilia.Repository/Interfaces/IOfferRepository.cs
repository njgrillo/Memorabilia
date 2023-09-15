namespace Memorabilia.Repository.Interfaces;

public interface IOfferRepository
    : IDomainRepository<Entity.Offer>
{
    Task<Entity.Offer[]> GetAll(int userId);

    Task<Entity.Offer[]> GetAllAccepted(int userId);

    Task<Entity.Offer[]> GetAllExpired();

    Task<Entity.Offer[]> GetAllOpen(int? userId = null);
}
