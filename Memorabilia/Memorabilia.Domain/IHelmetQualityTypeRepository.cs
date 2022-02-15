using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IHelmetQualityTypeRepository
    {
        Task Add(Entities.HelmetQualityType helmetQualityType, CancellationToken cancellationToken = default);

        Task Delete(Entities.HelmetQualityType helmetQualityType, CancellationToken cancellationToken = default);

        Task<Entities.HelmetQualityType> Get(int id);

        Task<IEnumerable<Entities.HelmetQualityType>> GetAll();

        Task Update(Entities.HelmetQualityType helmetQualityType, CancellationToken cancellationToken = default);
    }
}
