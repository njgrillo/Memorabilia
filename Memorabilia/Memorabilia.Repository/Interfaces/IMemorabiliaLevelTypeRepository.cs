using Memorabilia.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IMemorabiliaLevelTypeRepository
    {
        Task Add(MemorabiliaLevelType memorabiliaLevelType, CancellationToken cancellationToken = default);

        Task Delete(MemorabiliaLevelType memorabiliaLevelType, CancellationToken cancellationToken = default);

        Task<MemorabiliaLevelType> Get(int id);

        Task Update(MemorabiliaLevelType memorabiliaLevelType, CancellationToken cancellationToken = default);
    }
}
