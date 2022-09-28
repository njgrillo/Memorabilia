using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface ITeamRepository
    {
        Task Add(Team team, CancellationToken cancellationToken = default);

        Task Delete(Team team, CancellationToken cancellationToken = default);

        Task<Team> Get(int id);

        Task<IEnumerable<Team>> GetAll(int? franchiseId = null, int? sportLeageLevelId = null);

        Task Update(Team team, CancellationToken cancellationToken = default);
    }
}
