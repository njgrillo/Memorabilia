using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IMemorabiliaPhotoRepository
    {
        Task Add(Entities.MemorabiliaPhoto memorabiliaPhoto, CancellationToken cancellationToken = default);

        Task Delete(Entities.MemorabiliaPhoto memorabiliaPhoto, CancellationToken cancellationToken = default);

        Task<Entities.MemorabiliaPhoto> Get(int id);

        Task Update(Entities.MemorabiliaPhoto memorabiliaPhoto, CancellationToken cancellationToken = default);
    }
}
