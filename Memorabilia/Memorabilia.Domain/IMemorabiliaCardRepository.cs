using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IMemorabiliaCardRepository
    {
        Task Add(Entities.MemorabiliaCard memorabiliaCard, CancellationToken cancellationToken = default);

        Task Delete(Entities.MemorabiliaCard memorabiliaCard, CancellationToken cancellationToken = default);

        Task<Entities.MemorabiliaCard> Get(int id);

        Task Update(Entities.MemorabiliaCard memorabiliaCard, CancellationToken cancellationToken = default);
    }
}
