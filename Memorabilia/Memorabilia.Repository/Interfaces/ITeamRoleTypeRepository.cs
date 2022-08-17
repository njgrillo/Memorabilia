using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface ITeamRoleTypeRepository
    {
        Task Add(TeamRoleType teamRoleType, CancellationToken cancellationToken = default);

        Task Delete(TeamRoleType teamRoleType, CancellationToken cancellationToken = default);

        Task<TeamRoleType> Get(int id);

        Task<IEnumerable<TeamRoleType>> GetAll();

        Task Update(TeamRoleType teamRoleType, CancellationToken cancellationToken = default);
    }
}
