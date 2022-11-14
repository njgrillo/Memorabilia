using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces;

public interface ILeaguePresidentRepository : IDomainRepository<LeaguePresident>
{
    Task<IEnumerable<LeaguePresident>> GetAll(int? sportLeagueLevelId = null, int? leagueId = null);
}
