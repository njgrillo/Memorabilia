using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces;

public interface ITeamLeagueRepository : IDomainRepository<TeamLeague>
{
    Task<IEnumerable<TeamLeague>> GetAll(int? teamId = null);
}
