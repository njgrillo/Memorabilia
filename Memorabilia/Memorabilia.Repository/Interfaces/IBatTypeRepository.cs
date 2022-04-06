using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IBatTypeRepository
    {
        Task Add(BatType batType, CancellationToken cancellationToken = default);

        Task Delete(BatType batType, CancellationToken cancellationToken = default);

        Task<BatType> Get(int id);

        Task<IEnumerable<BatType>> GetAll();

        Task Update(BatType batType, CancellationToken cancellationToken = default);
    }
}
