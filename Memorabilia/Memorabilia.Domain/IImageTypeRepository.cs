using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IImageTypeRepository
    {
        Task Add(Entities.ImageType imageType, CancellationToken cancellationToken = default);

        Task Delete(Entities.ImageType imageType, CancellationToken cancellationToken = default);

        Task<Entities.ImageType> Get(int id);

        Task<IEnumerable<Entities.ImageType>> GetAll();

        Task Update(Entities.ImageType imageType, CancellationToken cancellationToken = default);
    }
}
