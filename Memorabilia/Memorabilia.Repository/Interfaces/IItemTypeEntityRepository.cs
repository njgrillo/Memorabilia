namespace Memorabilia.Repository.Interfaces;

public interface IItemTypeEntityRepository<T> 
    : IDomainRepository<T> where T : DomainIdEntity
{
    Task<T[]> GetAll(int? itemTypeId = null);
}
