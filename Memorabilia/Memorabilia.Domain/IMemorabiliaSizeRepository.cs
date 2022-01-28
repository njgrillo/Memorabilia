using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IMemorabiliaSizeRepository
    {
        Task Add(Entities.MemorabiliaSize memorabiliaSize, CancellationToken cancellationToken = default);

        Task Delete(Entities.MemorabiliaSize memorabiliaSize, CancellationToken cancellationToken = default);

        Task<Entities.MemorabiliaSize> Get(int id);

        Task Update(Entities.MemorabiliaSize memorabiliaSize, CancellationToken cancellationToken = default);
    }
}
