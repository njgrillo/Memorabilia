namespace Memorabilia.Repository.Interfaces;

public interface IProposeTradeRepository
     : IDomainRepository<Entity.ProposeTrade>
{
    Task<Entity.ProposeTrade[]> GetAll(int userId);
}
