using Memorabilia.Domain.SearchModels.Memorabilia;

namespace Memorabilia.Repository.Interfaces;

public interface IMemorabiliaItemRepository : IDomainRepository<Domain.Entities.Memorabilia>
{
    Task<IEnumerable<Domain.Entities.Memorabilia>> GetAll(int userId);

    Task<PagedResult<Domain.Entities.Memorabilia>> GetAll(
        int userId,
        PageInfo pageInfo,
        MemorabiliaSearchCriteria memorabiliaSearchCriteria = null);

    Task<IEnumerable<Domain.Entities.Memorabilia>> GetAllUnsigned(int userId);
}
