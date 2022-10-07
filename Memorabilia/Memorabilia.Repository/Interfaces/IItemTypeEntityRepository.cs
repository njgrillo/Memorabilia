using DomainEntity = Framework.Library.Domain.Entity.DomainEntity;

namespace Memorabilia.Repository.Interfaces;

public interface IItemTypeEntityRepository<T> : IDomainRepository<T> where T : DomainEntity
{
    Task<IEnumerable<T>> GetAll(int? itemTypeId = null);
}
