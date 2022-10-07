using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces;

public interface ITeamChampionshipRepository : IDomainRepository<Champion>
{
    Task<IEnumerable<Champion>> GetAll(int? teamId = null);
}
