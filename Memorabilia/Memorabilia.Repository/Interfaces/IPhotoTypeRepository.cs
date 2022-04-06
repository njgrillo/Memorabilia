using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IPhotoTypeRepository
    {
        Task Add(PhotoType photoType, CancellationToken cancellationToken = default);

        Task Delete(PhotoType photoType, CancellationToken cancellationToken = default);

        Task<PhotoType> Get(int id);

        Task<IEnumerable<PhotoType>> GetAll();

        Task Update(PhotoType photoType, CancellationToken cancellationToken = default);
    }
}
