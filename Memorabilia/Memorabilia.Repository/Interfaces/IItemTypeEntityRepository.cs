namespace Memorabilia.Repository.Interfaces;

public interface IItemTypeEntityRepository<T> 
    : IDomainRepository<T> where T : Framework.Library.Domain.Entity.DomainEntity
{
    Task<T[]> GetAll(int? itemTypeId = null);
}
