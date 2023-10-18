namespace Memorabilia.Repository.Interfaces;

public interface IOfferRepository
    : IDomainRepository<Offer>
{
    Task<Offer[]> GetAll(int userId);

    Task<Offer[]> GetAllAccepted(int userId);

    Task<Offer[]> GetAllExpired();

    Task<Offer[]> GetAllOpen(int? userId = null);
}
