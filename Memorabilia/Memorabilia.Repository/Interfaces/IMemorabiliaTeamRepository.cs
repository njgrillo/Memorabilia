using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IMemorabiliaTeamRepository
    {
        Task Add(MemorabiliaTeam memorabiliaTeam, CancellationToken cancellationToken = default);

        Task Delete(IEnumerable<MemorabiliaTeam> memorabiliaTeams, CancellationToken cancellationToken = default);

        Task<MemorabiliaTeam> Get(int id);

        Task Update(MemorabiliaTeam memorabiliaTeam, CancellationToken cancellationToken = default);
    }
}
