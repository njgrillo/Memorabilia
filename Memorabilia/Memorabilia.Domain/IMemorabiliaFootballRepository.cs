using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IMemorabiliaFootballRepository
    {
        Task Add(Entities.MemorabiliaFootball memorabiliaFootballType, CancellationToken cancellationToken = default);

        Task Delete(Entities.MemorabiliaFootball memorabiliaFootballType, CancellationToken cancellationToken = default);

        Task<Entities.MemorabiliaFootball> Get(int id);

        Task Update(Entities.MemorabiliaFootball memorabiliaFootballType, CancellationToken cancellationToken = default);
    }
}
