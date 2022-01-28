using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface ITeamRepository
    {
        Task Add(Entities.Team team, CancellationToken cancellationToken = default);

        Task Delete(Entities.Team team, CancellationToken cancellationToken = default);

        Task<Entities.Team> Get(int id);

        Task<IEnumerable<Entities.Team>> GetAll();

        Task Update(Entities.Team team, CancellationToken cancellationToken = default);
    }
}
