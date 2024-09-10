namespace Memorabilia.Repository.Interfaces;

public interface IMountRushmoreRepository : IDomainRepository<MountRushmore>
{
    Task<PagedResult<MountRushmore>> GetAll(int userId, PageInfo pageInfo);

    Task<PagedResult<MountRushmore>> GetAllPublic(PageInfo pageInfo);
}
