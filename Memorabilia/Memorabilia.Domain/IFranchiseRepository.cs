using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IFranchiseRepository
    {
        Task Add(Entities.Franchise franchise, CancellationToken cancellationToken = default);

        Task Delete(Entities.Franchise franchise, CancellationToken cancellationToken = default);

        Task<Entities.Franchise> Get(int id);

        Task<IEnumerable<Entities.Franchise>> GetAll();

        Task Update(Entities.Franchise franchise, CancellationToken cancellationToken = default);
    }
}
