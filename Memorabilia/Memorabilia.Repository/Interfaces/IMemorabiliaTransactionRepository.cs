namespace Memorabilia.Repository.Interfaces;

public interface IMemorabiliaTransactionRepository 
    : IDomainRepository<Entity.MemorabiliaTransaction>
{
    Task<PagedResult<Entity.MemorabiliaTransaction>> GetAllPartialTrades(PageInfo pageInfo,
                                                                         int userId,
                                                                         MemorabiliaSearchCriteria memorabiliaSearchCriteria = null);

    Task<PagedResult<Entity.MemorabiliaTransaction>> GetAllSales(PageInfo pageInfo, 
                                                                 int userId,
                                                                 MemorabiliaSearchCriteria memorabiliaSearchCriteria = null);

    Task<PagedResult<Entity.MemorabiliaTransaction>> GetAllTrades(PageInfo pageInfo,
                                                                  int userId,
                                                                  MemorabiliaSearchCriteria memorabiliaSearchCriteria = null);
}
