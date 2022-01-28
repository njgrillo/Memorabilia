using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IAcquisitionTypeRepository
    {
        Task Add(Entities.AcquisitionType acquisitionType, CancellationToken cancellationToken = default);

        Task Delete(Entities.AcquisitionType acquisitionType, CancellationToken cancellationToken = default);

        Task<Entities.AcquisitionType> Get(int id);

        Task<IEnumerable<Entities.AcquisitionType>> GetAll();

        Task Update(Entities.AcquisitionType acquisitionType, CancellationToken cancellationToken = default);
    }
}
