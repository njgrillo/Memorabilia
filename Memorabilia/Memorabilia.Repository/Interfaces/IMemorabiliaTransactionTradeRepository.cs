namespace Memorabilia.Repository.Interfaces;

public interface IMemorabiliaTransactionTradeRepository
    : IDomainRepository<Entity.MemorabiliaTransactionTrade>
{
    Task<Entity.MemorabiliaTransactionTrade[]> GetAll(int memorabiliaTransactionId);
}
