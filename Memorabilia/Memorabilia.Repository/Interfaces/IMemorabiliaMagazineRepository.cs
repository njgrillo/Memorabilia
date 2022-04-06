using Memorabilia.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IMemorabiliaMagazineRepository
    {
        Task Add(MemorabiliaMagazine memorabiliaMagazine, CancellationToken cancellationToken = default);

        Task Delete(MemorabiliaMagazine memorabiliaMagazine, CancellationToken cancellationToken = default);

        Task<MemorabiliaMagazine> Get(int id);

        Task Update(MemorabiliaMagazine memorabiliaMagazine, CancellationToken cancellationToken = default);
    }
}
