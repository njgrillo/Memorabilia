using Memorabilia.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IMemorabiliaBrandRepository
    {
        Task Add(MemorabiliaBrand memorabiliaBrand, CancellationToken cancellationToken = default);

        Task Delete(MemorabiliaBrand memorabiliaBrand, CancellationToken cancellationToken = default);

        Task<MemorabiliaBrand> Get(int id);

        Task Update(MemorabiliaBrand memorabiliaBrand, CancellationToken cancellationToken = default);
    }
}
