using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IPewterRepository
    {
        Task Add(Entities.Pewter pewter, CancellationToken cancellationToken = default);

        Task Delete(Entities.Pewter pewter, CancellationToken cancellationToken = default);

        Task<Entities.Pewter> Get(int id);

        Task<IEnumerable<Entities.Pewter>> GetAll();

        Task Update(Entities.Pewter pewter, CancellationToken cancellationToken = default);
    }
}
