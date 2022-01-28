using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IMemorabiliaBaseballTypeRepository
    {
        Task Add(Entities.MemorabiliaBaseballType memorabiliaBaseballType, CancellationToken cancellationToken = default);

        Task Delete(Entities.MemorabiliaBaseballType memorabiliaBaseballType, CancellationToken cancellationToken = default);

        Task<Entities.MemorabiliaBaseballType> Get(int id);

        Task Update(Entities.MemorabiliaBaseballType memorabiliaBaseballType, CancellationToken cancellationToken = default);
    }
}
