using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IMemorabiliaOrientationRepository
    {
        Task Add(Entities.MemorabiliaOrientation memorabiliaOrientation, CancellationToken cancellationToken = default);

        Task Delete(Entities.MemorabiliaOrientation memorabiliaOrientation, CancellationToken cancellationToken = default);

        Task<Entities.MemorabiliaOrientation> Get(int id);

        Task Update(Entities.MemorabiliaOrientation memorabiliaOrientation, CancellationToken cancellationToken = default);
    }
}
