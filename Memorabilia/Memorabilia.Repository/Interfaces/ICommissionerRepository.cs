using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces;

public interface ICommissionerRepository : IDomainRepository<Commissioner>
{
    Task<IEnumerable<Commissioner>> GetAll(int? sportLeagueLevelId = null);
}
