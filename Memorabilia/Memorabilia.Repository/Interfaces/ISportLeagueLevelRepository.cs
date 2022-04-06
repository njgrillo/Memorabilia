using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface ISportLeagueLevelRepository
    {
        Task Add(SportLeagueLevel sportLeagueLevel, CancellationToken cancellationToken = default);

        Task Delete(SportLeagueLevel sportLeagueLevel, CancellationToken cancellationToken = default);

        Task<SportLeagueLevel> Get(int id);

        Task<IEnumerable<SportLeagueLevel>> GetAll();

        Task Update(SportLeagueLevel sportLeagueLevel, CancellationToken cancellationToken = default);
    }
}
