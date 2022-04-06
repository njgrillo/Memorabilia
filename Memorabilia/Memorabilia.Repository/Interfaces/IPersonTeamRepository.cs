using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IPersonTeamRepository
    {
        Task Add(PersonTeam personTeam, CancellationToken cancellationToken = default);

        Task Delete(PersonTeam personTeam, CancellationToken cancellationToken = default);

        Task<PersonTeam> Get(int id);

        Task<IEnumerable<PersonTeam>> GetAll(int? personId = null);

        Task Update(PersonTeam personTeam, CancellationToken cancellationToken = default);
    }
}
