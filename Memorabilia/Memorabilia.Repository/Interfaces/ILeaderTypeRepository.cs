using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface ILeaderTypeRepository
    {
        Task Add(LeaderType leaderType, CancellationToken cancellationToken = default);

        Task Delete(LeaderType leaderType, CancellationToken cancellationToken = default);

        Task<LeaderType> Get(int id);

        Task<IEnumerable<LeaderType>> GetAll();

        Task Update(LeaderType leaderType, CancellationToken cancellationToken = default);
    }
}
