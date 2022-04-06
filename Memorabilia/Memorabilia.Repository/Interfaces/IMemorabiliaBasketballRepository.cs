using Memorabilia.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IMemorabiliaBasketballRepository
    {
        Task Add(MemorabiliaBasketball memorabiliaBasketballType, CancellationToken cancellationToken = default);

        Task Delete(MemorabiliaBasketball memorabiliaBasketballType, CancellationToken cancellationToken = default);

        Task<MemorabiliaBasketball> Get(int id);

        Task Update(MemorabiliaBasketball memorabiliaBasketballType, CancellationToken cancellationToken = default);
    }
}
