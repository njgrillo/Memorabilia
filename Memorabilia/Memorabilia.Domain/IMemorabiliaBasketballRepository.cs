using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IMemorabiliaBasketballRepository
    {
        Task Add(Entities.MemorabiliaBasketball memorabiliaBasketballType, CancellationToken cancellationToken = default);

        Task Delete(Entities.MemorabiliaBasketball memorabiliaBasketballType, CancellationToken cancellationToken = default);

        Task<Entities.MemorabiliaBasketball> Get(int id);

        Task Update(Entities.MemorabiliaBasketball memorabiliaBasketballType, CancellationToken cancellationToken = default);
    }
}
