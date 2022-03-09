using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IMemorabiliaImageRepository
    {
        Task Add(Entities.MemorabiliaImage memorabiliaImage, CancellationToken cancellationToken = default);

        Task Delete(Entities.MemorabiliaImage memorabiliaImage, CancellationToken cancellationToken = default);

        Task<Entities.MemorabiliaImage> Get(int id);

        Task<List<Entities.MemorabiliaImage>> GetAll(int memorabiliaId);

        Task Update(Entities.MemorabiliaImage memorabiliaImage, CancellationToken cancellationToken = default);
    }
}
