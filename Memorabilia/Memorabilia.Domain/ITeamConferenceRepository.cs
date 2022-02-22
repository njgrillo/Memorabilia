using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface ITeamConferenceRepository
    {
        Task Add(Entities.TeamConference teamConference, CancellationToken cancellationToken = default);

        Task Delete(Entities.TeamConference teamConference, CancellationToken cancellationToken = default);

        Task<Entities.TeamConference> Get(int id);

        Task<IEnumerable<Entities.TeamConference>> GetAll(int? teamId = null);

        Task Update(Entities.TeamConference teamConference, CancellationToken cancellationToken = default);
    }
}
