using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IMemorabiliaBookRepository
    {
        Task Add(Entities.MemorabiliaBook memorabiliaBook, CancellationToken cancellationToken = default);

        Task Delete(Entities.MemorabiliaBook memorabiliaBook, CancellationToken cancellationToken = default);

        Task<Entities.MemorabiliaBook> Get(int id);

        Task Update(Entities.MemorabiliaBook memorabiliaBook, CancellationToken cancellationToken = default);
    }
}
