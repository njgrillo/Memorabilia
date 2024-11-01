namespace Memorabilia.Repository.Interfaces;

public interface IMountRushmoreRepository : IDomainRepository<MountRushmore>
{
    Task<PagedResult<MountRushmore>> GetAll(int userId, PageInfo pageInfo, string filter = null);

    Task<PagedResult<MountRushmore>> GetAllPublic(PageInfo pageInfo);
}
