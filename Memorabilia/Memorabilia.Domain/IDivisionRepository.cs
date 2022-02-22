using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IDivisionRepository
    {
        Task Add(Entities.Division division, CancellationToken cancellationToken = default);

        Task Delete(Entities.Division division, CancellationToken cancellationToken = default);

        Task<Entities.Division> Get(int id);

        Task<IEnumerable<Entities.Division>> GetAll();

        Task Update(Entities.Division division, CancellationToken cancellationToken = default);
    }
}
