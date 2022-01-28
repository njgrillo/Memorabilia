using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IMagazineTypeRepository
    {
        Task Add(Entities.MagazineType magazineType, CancellationToken cancellationToken = default);

        Task Delete(Entities.MagazineType magazineType, CancellationToken cancellationToken = default);

        Task<Entities.MagazineType> Get(int id);

        Task<IEnumerable<Entities.MagazineType>> GetAll();

        Task Update(Entities.MagazineType magazineType, CancellationToken cancellationToken = default);
    }
}
