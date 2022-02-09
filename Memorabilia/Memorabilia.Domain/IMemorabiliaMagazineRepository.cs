using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IMemorabiliaMagazineRepository
    {
        Task Add(Entities.MemorabiliaMagazine memorabiliaMagazine, CancellationToken cancellationToken = default);

        Task Delete(Entities.MemorabiliaMagazine memorabiliaMagazine, CancellationToken cancellationToken = default);

        Task<Entities.MemorabiliaMagazine> Get(int id);

        Task Update(Entities.MemorabiliaMagazine memorabiliaMagazine, CancellationToken cancellationToken = default);
    }
}
