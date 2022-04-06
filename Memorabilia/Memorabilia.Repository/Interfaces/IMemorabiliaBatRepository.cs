using Memorabilia.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IMemorabiliaBatRepository
    {
        Task Add(MemorabiliaBat memorabiliaBat, CancellationToken cancellationToken = default);

        Task Delete(MemorabiliaBat memorabiliaBat, CancellationToken cancellationToken = default);

        Task<MemorabiliaBat> Get(int id);

        Task Update(MemorabiliaBat memorabiliaBat, CancellationToken cancellationToken = default);
    }
}
