using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IPersonTeamRepository
    {
        Task Add(Entities.PersonTeam personTeam, CancellationToken cancellationToken = default);

        Task Delete(Entities.PersonTeam personTeam, CancellationToken cancellationToken = default);

        Task<Entities.PersonTeam> Get(int id);

        Task<IEnumerable<Entities.PersonTeam>> GetAll(int? personId = null);

        Task Update(Entities.PersonTeam personTeam, CancellationToken cancellationToken = default);
    }
}
