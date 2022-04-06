using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface ISpotRepository
    {
        Task Add(Spot spot, CancellationToken cancellationToken = default);

        Task Delete(Spot spot, CancellationToken cancellationToken = default);

        Task<Spot> Get(int id);

        Task<IEnumerable<Spot>> GetAll();

        Task Update(Spot spot, CancellationToken cancellationToken = default);
    }
}
