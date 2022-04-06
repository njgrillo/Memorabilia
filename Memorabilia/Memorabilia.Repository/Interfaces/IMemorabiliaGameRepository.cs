using Memorabilia.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IMemorabiliaGameRepository
    {
        Task Add(MemorabiliaGame memorabiliaGame, CancellationToken cancellationToken = default);

        Task Delete(MemorabiliaGame memorabiliaGame, CancellationToken cancellationToken = default);

        Task<MemorabiliaGame> Get(int id);

        Task Update(MemorabiliaGame memorabiliaGame, CancellationToken cancellationToken = default);
    }
}
