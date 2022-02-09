using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IMemorabiliaBatRepository
    {
        Task Add(Entities.MemorabiliaBat memorabiliaBat, CancellationToken cancellationToken = default);

        Task Delete(Entities.MemorabiliaBat memorabiliaBat, CancellationToken cancellationToken = default);

        Task<Entities.MemorabiliaBat> Get(int id);

        Task Update(Entities.MemorabiliaBat memorabiliaBat, CancellationToken cancellationToken = default);
    }
}
