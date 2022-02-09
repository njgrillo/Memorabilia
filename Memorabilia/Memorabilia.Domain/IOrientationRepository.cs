using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IOrientationRepository
    {
        Task Add(Entities.Orientation orientation, CancellationToken cancellationToken = default);

        Task Delete(Entities.Orientation orientation, CancellationToken cancellationToken = default);

        Task<Entities.Orientation> Get(int id);

        Task<IEnumerable<Entities.Orientation>> GetAll();

        Task Update(Entities.Orientation orientation, CancellationToken cancellationToken = default);
    }
}
