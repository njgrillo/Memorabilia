using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IHallOfFameRepository
    {
        Task Add(Entities.HallOfFame hallOfFame, CancellationToken cancellationToken = default);

        Task Delete(Entities.HallOfFame hallOfFame, CancellationToken cancellationToken = default);

        Task<Entities.HallOfFame> Get(int id);

        Task<IEnumerable<Entities.HallOfFame>> GetAll(int? personId = null);

        Task Update(Entities.HallOfFame hallOfFame, CancellationToken cancellationToken = default);
    }
}
