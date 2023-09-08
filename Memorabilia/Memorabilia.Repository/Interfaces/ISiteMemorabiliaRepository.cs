namespace Memorabilia.Repository.Interfaces;

public interface ISiteMemorabiliaRepository
    : IDomainRepository<Entity.Memorabilia>
{
    Task<PagedResult<Entity.Memorabilia>> GetAll(PageInfo pageInfo,
                                                 MemorabiliaSearchCriteria memorabiliaSearchCriteria = null,
                                                 int? userId = null);

    Task<PagedResult<Entity.Memorabilia>> GetAllByUser(int userId,
                                                       PageInfo pageInfo,
                                                       MemorabiliaSearchCriteria memorabiliaSearchCriteria = null);
}
