namespace Memorabilia.Repository.Interfaces;

public interface IMemorabiliaTransactionRepository 
    : IDomainRepository<MemorabiliaTransaction>
{
    Task<PagedResult<MemorabiliaTransaction>> GetAllPartialTrades(PageInfo pageInfo,
                                                                         int userId,
                                                                         MemorabiliaSearchCriteria memorabiliaSearchCriteria = null);

    Task<PagedResult<MemorabiliaTransaction>> GetAllSales(PageInfo pageInfo, 
                                                                 int userId,
                                                                 MemorabiliaSearchCriteria memorabiliaSearchCriteria = null);

    Task<PagedResult<MemorabiliaTransaction>> GetAllTrades(PageInfo pageInfo,
                                                                  int userId,
                                                                  MemorabiliaSearchCriteria memorabiliaSearchCriteria = null);
}
