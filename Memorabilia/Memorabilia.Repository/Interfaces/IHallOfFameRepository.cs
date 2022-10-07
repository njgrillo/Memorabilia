using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces;

public interface IHallOfFameRepository : IDomainRepository<HallOfFame>
{
    Task<IEnumerable<HallOfFame>> GetAll(int? personId = null);
}
