using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IPhotoTypeRepository
    {
        Task Add(Entities.PhotoType photoType, CancellationToken cancellationToken = default);

        Task Delete(Entities.PhotoType photoType, CancellationToken cancellationToken = default);

        Task<Entities.PhotoType> Get(int id);

        Task<IEnumerable<Entities.PhotoType>> GetAll();

        Task Update(Entities.PhotoType photoType, CancellationToken cancellationToken = default);
    }
}
