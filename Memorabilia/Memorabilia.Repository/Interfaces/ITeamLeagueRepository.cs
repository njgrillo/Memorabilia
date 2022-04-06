using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface ITeamLeagueRepository
    {
        Task Add(TeamLeague teamLeague, CancellationToken cancellationToken = default);

        Task Delete(TeamLeague teamLeague, CancellationToken cancellationToken = default);

        Task<TeamLeague> Get(int id);

        Task<IEnumerable<TeamLeague>> GetAll(int? teamId = null);

        Task Update(TeamLeague teamLeague, CancellationToken cancellationToken = default);
    }
}
