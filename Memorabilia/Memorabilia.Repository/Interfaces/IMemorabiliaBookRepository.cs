using Memorabilia.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IMemorabiliaBookRepository
    {
        Task Add(MemorabiliaBook memorabiliaBook, CancellationToken cancellationToken = default);

        Task Delete(MemorabiliaBook memorabiliaBook, CancellationToken cancellationToken = default);

        Task<MemorabiliaBook> Get(int id);

        Task Update(MemorabiliaBook memorabiliaBook, CancellationToken cancellationToken = default);
    }
}
