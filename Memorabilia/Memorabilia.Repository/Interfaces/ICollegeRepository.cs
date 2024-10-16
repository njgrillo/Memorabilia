namespace Memorabilia.Repository.Interfaces;

public interface ICollegeRepository
    : IDomainRepository<College>
{
    Task<PagedResult<College>> GetAll(PageInfo pageInfo, string filter = null);
}