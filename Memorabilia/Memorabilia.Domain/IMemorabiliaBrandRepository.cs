using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IMemorabiliaBrandRepository
    {
        Task Add(Entities.MemorabiliaBrand memorabiliaBrand, CancellationToken cancellationToken = default);

        Task Delete(Entities.MemorabiliaBrand memorabiliaBrand, CancellationToken cancellationToken = default);

        Task<Entities.MemorabiliaBrand> Get(int id);

        Task Update(Entities.MemorabiliaBrand memorabiliaBrand, CancellationToken cancellationToken = default);
    }
}
