using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IFootballTypeRepository
    {
        Task Add(Entities.FootballType footballType, CancellationToken cancellationToken = default);

        Task Delete(Entities.FootballType footballType, CancellationToken cancellationToken = default);

        Task<Entities.FootballType> Get(int id);

        Task<IEnumerable<Entities.FootballType>> GetAll();

        Task Update(Entities.FootballType footballType, CancellationToken cancellationToken = default);
    }
}
