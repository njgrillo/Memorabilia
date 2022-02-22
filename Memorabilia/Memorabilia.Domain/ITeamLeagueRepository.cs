using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface ITeamLeagueRepository
    {
        Task Add(Entities.TeamLeague teamLeague, CancellationToken cancellationToken = default);

        Task Delete(Entities.TeamLeague teamLeague, CancellationToken cancellationToken = default);

        Task<Entities.TeamLeague> Get(int id);

        Task<IEnumerable<Entities.TeamLeague>> GetAll(int? teamId = null);

        Task Update(Entities.TeamLeague teamLeague, CancellationToken cancellationToken = default);
    }
}
