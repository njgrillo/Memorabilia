namespace Memorabilia.Repository.Interfaces;

public interface IPrivateSigningRepository : IDomainRepository<Entity.PrivateSigning>
{
    Task<PagedResult<Entity.PrivateSigning>> GetAll(PageInfo pageInfo);
}
