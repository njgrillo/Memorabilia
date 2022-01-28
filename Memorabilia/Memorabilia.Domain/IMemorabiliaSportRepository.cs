using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IMemorabiliaSportRepository
    {
        Task Add(Entities.MemorabiliaSport memorabiliaSport, CancellationToken cancellationToken = default);

        Task Delete(Entities.MemorabiliaSport memorabiliaSport, CancellationToken cancellationToken = default);

        Task<Entities.MemorabiliaSport> Get(int id);

        Task Update(Entities.MemorabiliaSport memorabiliaSport, CancellationToken cancellationToken = default);
    }
}
