using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IMemorabiliaImageRepository
    {
        Task Add(MemorabiliaImage memorabiliaImage, CancellationToken cancellationToken = default);

        Task Delete(MemorabiliaImage memorabiliaImage, CancellationToken cancellationToken = default);

        Task<MemorabiliaImage> Get(int id);

        Task<List<MemorabiliaImage>> GetAll(int memorabiliaId);

        Task Update(MemorabiliaImage memorabiliaImage, CancellationToken cancellationToken = default);
    }
}
