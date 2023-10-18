namespace Memorabilia.Repository.Interfaces;

public interface IProposeTradeRepository
     : IDomainRepository<ProposeTrade>
{
    Task<ProposeTrade[]> GetAll(int userId);

    Task<ProposeTrade[]> GetAllAccepted(int userId);

    Task<ProposeTrade[]> GetAllExpired();

    Task<ProposeTrade[]> GetAllOpen(int? userId = null);
}
