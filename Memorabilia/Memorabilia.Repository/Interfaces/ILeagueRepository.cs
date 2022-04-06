using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface ILeagueRepository
    {
        Task Add(League league, CancellationToken cancellationToken = default);

        Task Delete(League league, CancellationToken cancellationToken = default);

        Task<League> Get(int id);

        Task<IEnumerable<League>> GetAll();

        Task Update(League league, CancellationToken cancellationToken = default);
    }
}
