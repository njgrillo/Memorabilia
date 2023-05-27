using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces;

public interface ITeamRepository : IDomainRepository<Team>
{
    Task<IEnumerable<Team>> GetAll(int? franchiseId = null, int? sportLeagueLevelId = null, int? sportId = null);

    Task<Team[]> GetAllCurrentTeams(int? sportId = null);
}
