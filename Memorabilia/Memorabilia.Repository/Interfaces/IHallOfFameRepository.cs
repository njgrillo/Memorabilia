using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IHallOfFameRepository
    {
        Task Add(HallOfFame hallOfFame, CancellationToken cancellationToken = default);

        Task Delete(HallOfFame hallOfFame, CancellationToken cancellationToken = default);

        Task<HallOfFame> Get(int id);

        Task<IEnumerable<HallOfFame>> GetAll(int? personId = null);

        Task Update(HallOfFame hallOfFame, CancellationToken cancellationToken = default);
    }
}
