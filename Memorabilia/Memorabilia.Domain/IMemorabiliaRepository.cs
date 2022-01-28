using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IMemorabiliaRepository
    {
        Task Add(Entities.Memorabilia memorabilia, CancellationToken cancellationToken = default);

        Task Delete(Entities.Memorabilia memorabilia, CancellationToken cancellationToken = default);

        Task<Entities.Memorabilia> Get(int id);

        Task<IEnumerable<Entities.Memorabilia>> GetAll(int userId);

        Task Update(Entities.Memorabilia memorabilia, CancellationToken cancellationToken = default);
    }
}
