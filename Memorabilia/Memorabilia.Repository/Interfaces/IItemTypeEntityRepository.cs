namespace Memorabilia.Repository.Interfaces;

public interface IItemTypeEntityRepository<T> 
    : IDomainRepository<T> where T : Domain.Entity
{
    Task<T[]> GetAll(int? itemTypeId = null);
}
