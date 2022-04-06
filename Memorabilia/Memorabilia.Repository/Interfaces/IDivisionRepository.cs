using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IDivisionRepository
    {
        Task Add(Division division, CancellationToken cancellationToken = default);

        Task Delete(Division division, CancellationToken cancellationToken = default);

        Task<Division> Get(int id);

        Task<IEnumerable<Division>> GetAll();

        Task Update(Division division, CancellationToken cancellationToken = default);
    }
}
