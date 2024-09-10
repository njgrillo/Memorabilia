namespace Memorabilia.Repository.Interfaces;

public interface IDisplayCaseRepository : IDomainRepository<DisplayCase>
{
    Task<PagedResult<DisplayCase>> GetAll(int userId, PageInfo pageInfo);

    Task<PagedResult<DisplayCase>> GetAllPublic(PageInfo pageInfo);
}
