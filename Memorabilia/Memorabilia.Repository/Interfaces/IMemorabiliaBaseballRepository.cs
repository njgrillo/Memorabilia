using Memorabilia.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IMemorabiliaBaseballRepository
    {
        Task Add(MemorabiliaBaseball memorabiliaBaseball, CancellationToken cancellationToken = default);

        Task Delete(MemorabiliaBaseball memorabiliaBaseball, CancellationToken cancellationToken = default);

        Task<MemorabiliaBaseball> Get(int id);

        Task Update(MemorabiliaBaseball memorabiliaBaseball, CancellationToken cancellationToken = default);
    }
}
