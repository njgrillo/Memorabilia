using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IAcquisitionTypeRepository
    {
        Task Add(AcquisitionType acquisitionType, CancellationToken cancellationToken = default);

        Task Delete(AcquisitionType acquisitionType, CancellationToken cancellationToken = default);

        Task<AcquisitionType> Get(int id);

        Task<IEnumerable<AcquisitionType>> GetAll();

        Task Update(AcquisitionType acquisitionType, CancellationToken cancellationToken = default);
    }
}
