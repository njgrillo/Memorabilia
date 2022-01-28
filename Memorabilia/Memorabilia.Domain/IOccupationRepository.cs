using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IOccupationRepository
    {
        Task Add(Entities.Occupation occupation, CancellationToken cancellationToken = default);

        Task Delete(Entities.Occupation occupation, CancellationToken cancellationToken = default);

        Task<Entities.Occupation> Get(int id);

        Task<IEnumerable<Entities.Occupation>> GetAll();

        Task Update(Entities.Occupation occupation, CancellationToken cancellationToken = default);
    }
}
