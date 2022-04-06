using Memorabilia.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IMemorabiliaOrientationRepository
    {
        Task Add(MemorabiliaOrientation memorabiliaOrientation, CancellationToken cancellationToken = default);

        Task Delete(MemorabiliaOrientation memorabiliaOrientation, CancellationToken cancellationToken = default);

        Task<MemorabiliaOrientation> Get(int id);

        Task Update(MemorabiliaOrientation memorabiliaOrientation, CancellationToken cancellationToken = default);
    }
}
