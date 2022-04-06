using Memorabilia.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IMemorabiliaCardRepository
    {
        Task Add(MemorabiliaCard memorabiliaCard, CancellationToken cancellationToken = default);

        Task Delete(MemorabiliaCard memorabiliaCard, CancellationToken cancellationToken = default);

        Task<MemorabiliaCard> Get(int id);

        Task Update(MemorabiliaCard memorabiliaCard, CancellationToken cancellationToken = default);
    }
}
