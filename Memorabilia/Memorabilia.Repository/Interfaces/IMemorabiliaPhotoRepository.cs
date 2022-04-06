using Memorabilia.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IMemorabiliaPhotoRepository
    {
        Task Add(MemorabiliaPhoto memorabiliaPhoto, CancellationToken cancellationToken = default);

        Task Delete(MemorabiliaPhoto memorabiliaPhoto, CancellationToken cancellationToken = default);

        Task<MemorabiliaPhoto> Get(int id);

        Task Update(MemorabiliaPhoto memorabiliaPhoto, CancellationToken cancellationToken = default);
    }
}
