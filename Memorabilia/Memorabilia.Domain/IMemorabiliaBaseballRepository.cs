using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IMemorabiliaBaseballRepository
    {
        Task Add(Entities.MemorabiliaBaseball memorabiliaBaseball, CancellationToken cancellationToken = default);

        Task Delete(Entities.MemorabiliaBaseball memorabiliaBaseball, CancellationToken cancellationToken = default);

        Task<Entities.MemorabiliaBaseball> Get(int id);

        Task Update(Entities.MemorabiliaBaseball memorabiliaBaseball, CancellationToken cancellationToken = default);
    }
}
