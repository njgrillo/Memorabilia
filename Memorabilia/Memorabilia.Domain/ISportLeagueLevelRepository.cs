using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface ISportLeagueLevelRepository
    {
        Task Add(Entities.SportLeagueLevel sportLeagueLevel, CancellationToken cancellationToken = default);

        Task Delete(Entities.SportLeagueLevel sportLeagueLevel, CancellationToken cancellationToken = default);

        Task<Entities.SportLeagueLevel> Get(int id);

        Task<IEnumerable<Entities.SportLeagueLevel>> GetAll();

        Task Update(Entities.SportLeagueLevel sportLeagueLevel, CancellationToken cancellationToken = default);
    }
}
