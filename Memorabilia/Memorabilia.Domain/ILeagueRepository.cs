using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface ILeagueRepository
    {
        Task Add(Entities.League league, CancellationToken cancellationToken = default);

        Task Delete(Entities.League league, CancellationToken cancellationToken = default);

        Task<Entities.League> Get(int id);

        Task<IEnumerable<Entities.League>> GetAll();

        Task Update(Entities.League league, CancellationToken cancellationToken = default);
    }
}
