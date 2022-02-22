using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface ICommissionerRepository
    {
        Task Add(Entities.Commissioner commissioner, CancellationToken cancellationToken = default);

        Task Delete(Entities.Commissioner commissioner, CancellationToken cancellationToken = default);

        Task<Entities.Commissioner> Get(int id);

        Task<IEnumerable<Entities.Commissioner>> GetAll(int? sportLeagueLevelId = null);

        Task Update(Entities.Commissioner commissioner, CancellationToken cancellationToken = default);
    }
}
