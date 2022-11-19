namespace Memorabilia.Repository.Interfaces;

public interface IMemorabiliaItemRepository : IDomainRepository<Domain.Entities.Memorabilia>
{
    Task<PagedResult<Domain.Entities.Memorabilia>> GetAll(
        int userId, 
        PageInfo pageInfo,
        Expression<Func<Domain.Entities.Memorabilia, bool>> filter = null);

    Task<IEnumerable<Domain.Entities.Memorabilia>> GetAll(int userId);

    Task<IEnumerable<Domain.Entities.Memorabilia>> GetAllUnsigned(int userId);
}
