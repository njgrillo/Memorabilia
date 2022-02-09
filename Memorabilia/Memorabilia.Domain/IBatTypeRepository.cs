using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IBatTypeRepository
    {
        Task Add(Entities.BatType batType, CancellationToken cancellationToken = default);

        Task Delete(Entities.BatType batType, CancellationToken cancellationToken = default);

        Task<Entities.BatType> Get(int id);

        Task<IEnumerable<Entities.BatType>> GetAll();

        Task Update(Entities.BatType batType, CancellationToken cancellationToken = default);
    }
}
