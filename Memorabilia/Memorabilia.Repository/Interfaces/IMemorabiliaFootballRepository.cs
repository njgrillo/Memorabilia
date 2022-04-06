using Memorabilia.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IMemorabiliaFootballRepository
    {
        Task Add(MemorabiliaFootball memorabiliaFootballType, CancellationToken cancellationToken = default);

        Task Delete(MemorabiliaFootball memorabiliaFootballType, CancellationToken cancellationToken = default);

        Task<MemorabiliaFootball> Get(int id);

        Task Update(MemorabiliaFootball memorabiliaFootballType, CancellationToken cancellationToken = default);
    }
}
