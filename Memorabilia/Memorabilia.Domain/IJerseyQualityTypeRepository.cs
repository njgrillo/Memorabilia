using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IJerseyQualityTypeRepository
    {
        Task Add(Entities.JerseyQualityType jerseyQualityType, CancellationToken cancellationToken = default);

        Task Delete(Entities.JerseyQualityType jerseyQualityType, CancellationToken cancellationToken = default);

        Task<Entities.JerseyQualityType> Get(int id);

        Task<IEnumerable<Entities.JerseyQualityType>> GetAll();

        Task Update(Entities.JerseyQualityType jerseyQualityType, CancellationToken cancellationToken = default);
    }
}
