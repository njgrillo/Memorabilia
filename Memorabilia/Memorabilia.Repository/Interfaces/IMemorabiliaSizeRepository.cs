using Memorabilia.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IMemorabiliaSizeRepository
    {
        Task Add(MemorabiliaSize memorabiliaSize, CancellationToken cancellationToken = default);

        Task Delete(MemorabiliaSize memorabiliaSize, CancellationToken cancellationToken = default);

        Task<MemorabiliaSize> Get(int id);

        Task Update(MemorabiliaSize memorabiliaSize, CancellationToken cancellationToken = default);
    }
}
