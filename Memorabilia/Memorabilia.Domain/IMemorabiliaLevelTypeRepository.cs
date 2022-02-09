using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IMemorabiliaLevelTypeRepository
    {
        Task Add(Entities.MemorabiliaLevelType memorabiliaLevelType, CancellationToken cancellationToken = default);

        Task Delete(Entities.MemorabiliaLevelType memorabiliaLevelType, CancellationToken cancellationToken = default);

        Task<Entities.MemorabiliaLevelType> Get(int id);

        Task Update(Entities.MemorabiliaLevelType memorabiliaLevelType, CancellationToken cancellationToken = default);
    }
}
