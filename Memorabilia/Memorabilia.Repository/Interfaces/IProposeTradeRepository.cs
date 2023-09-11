namespace Memorabilia.Repository.Interfaces;

public interface IProposeTradeRepository
     : IDomainRepository<Entity.ProposeTrade>
{
    Task<Entity.ProposeTrade[]> GetAll(int userId);

    Task<Entity.ProposeTrade[]> GetAllAccepted(int userId);

    Task<Entity.ProposeTrade[]> GetAllExpired();

    Task<Entity.ProposeTrade[]> GetAllOpen(int? userId = null);
}
