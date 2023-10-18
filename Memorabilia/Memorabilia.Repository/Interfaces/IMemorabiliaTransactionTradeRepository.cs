namespace Memorabilia.Repository.Interfaces;

public interface IMemorabiliaTransactionTradeRepository
    : IDomainRepository<MemorabiliaTransactionTrade>
{
    Task<MemorabiliaTransactionTrade[]> GetAll(int memorabiliaTransactionId);
}
