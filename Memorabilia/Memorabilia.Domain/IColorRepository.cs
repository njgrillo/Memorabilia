using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IColorRepository
    {
        Task Add(Entities.Color color, CancellationToken cancellationToken = default);

        Task Delete(Entities.Color color, CancellationToken cancellationToken = default);

        Task<Entities.Color> Get(int id);

        Task<IEnumerable<Entities.Color>> GetAll();

        Task Update(Entities.Color color, CancellationToken cancellationToken = default);
    }
}
