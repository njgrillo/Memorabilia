using Memorabilia.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IMemorabiliaSportRepository
    {
        Task Add(MemorabiliaSport memorabiliaSport, CancellationToken cancellationToken = default);

        Task Delete(MemorabiliaSport memorabiliaSport, CancellationToken cancellationToken = default);

        Task<MemorabiliaSport> Get(int id);

        Task Update(MemorabiliaSport memorabiliaSport, CancellationToken cancellationToken = default);
    }
}
