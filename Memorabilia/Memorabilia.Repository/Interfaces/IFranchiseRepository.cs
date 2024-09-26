namespace Memorabilia.Repository.Interfaces;

public interface IFranchiseRepository
    : IDomainRepository<Franchise>
{
    Task<PagedResult<Franchise>> GetAll(PageInfo pageInfo, string filter = null);
}
