namespace Memorabilia.Repository.Interfaces;

public interface IPrivateSigningCustomItemGroupRepository
    : IDomainRepository<Entity.PrivateSigningCustomItemGroup>
{
    Task<Entity.PrivateSigningCustomItemGroup[]> GetAll(int userId);
}
