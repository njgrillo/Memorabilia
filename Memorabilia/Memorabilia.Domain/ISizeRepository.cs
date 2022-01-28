using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface ISizeRepository
    {
        Task Add(Entities.Size size, CancellationToken cancellationToken = default);

        Task Delete(Entities.Size size, CancellationToken cancellationToken = default);

        Task<Entities.Size> Get(int id);

        Task<IEnumerable<Entities.Size>> GetAll();

        Task Update(Entities.Size size, CancellationToken cancellationToken = default);
    }
}
