using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface ISportRepository
    {
        Task Add(Entities.Sport sport, CancellationToken cancellationToken = default);

        Task Delete(Entities.Sport sport, CancellationToken cancellationToken = default);

        Task<Entities.Sport> Get(int id);

        Task<IEnumerable<Entities.Sport>> GetAll();

        Task Update(Entities.Sport sport, CancellationToken cancellationToken = default);
    }
}
