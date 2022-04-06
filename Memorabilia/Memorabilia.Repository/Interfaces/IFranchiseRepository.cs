using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IFranchiseRepository
    {
        Task Add(Franchise franchise, CancellationToken cancellationToken = default);

        Task Delete(Franchise franchise, CancellationToken cancellationToken = default);

        Task<Franchise> Get(int id);

        Task<IEnumerable<Franchise>> GetAll();

        Task Update(Franchise franchise, CancellationToken cancellationToken = default);
    }
}
