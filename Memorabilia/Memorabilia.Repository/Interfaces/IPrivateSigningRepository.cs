namespace Memorabilia.Repository.Interfaces;

public interface IPrivateSigningRepository : IDomainRepository<PrivateSigning>
{
    Task<PagedResult<PrivateSigning>> GetAll(PageInfo pageInfo, int? userId = null);
}
