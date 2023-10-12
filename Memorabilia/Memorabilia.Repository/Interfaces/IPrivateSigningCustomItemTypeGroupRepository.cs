namespace Memorabilia.Repository.Interfaces;

public interface IPrivateSigningCustomItemTypeGroupRepository
    : IDomainRepository<Entity.PrivateSigningCustomItemTypeGroup>
{
    Task<Entity.PrivateSigningCustomItemTypeGroup[]> GetAll(int userId);
}
