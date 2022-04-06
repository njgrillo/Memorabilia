using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IMagazineTypeRepository
    {
        Task Add(MagazineType magazineType, CancellationToken cancellationToken = default);

        Task Delete(MagazineType magazineType, CancellationToken cancellationToken = default);

        Task<MagazineType> Get(int id);

        Task<IEnumerable<MagazineType>> GetAll();

        Task Update(MagazineType magazineType, CancellationToken cancellationToken = default);
    }
}
