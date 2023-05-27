using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces;

public interface ICollectionRepository : IDomainRepository<Collection>
{
    Task<IEnumerable<Collection>> GetAll(int userId);
}
