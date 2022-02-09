using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IMemorabiliaGameRepository
    {
        Task Add(Entities.MemorabiliaGame memorabiliaGame, CancellationToken cancellationToken = default);

        Task Delete(Entities.MemorabiliaGame memorabiliaGame, CancellationToken cancellationToken = default);

        Task<Entities.MemorabiliaGame> Get(int id);

        Task Update(Entities.MemorabiliaGame memorabiliaGame, CancellationToken cancellationToken = default);
    }
}
