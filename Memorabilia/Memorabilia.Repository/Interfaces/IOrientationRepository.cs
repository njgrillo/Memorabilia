using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IOrientationRepository
    {
        Task Add(Orientation orientation, CancellationToken cancellationToken = default);

        Task Delete(Orientation orientation, CancellationToken cancellationToken = default);

        Task<Orientation> Get(int id);

        Task<IEnumerable<Orientation>> GetAll();

        Task Update(Orientation orientation, CancellationToken cancellationToken = default);
    }
}
