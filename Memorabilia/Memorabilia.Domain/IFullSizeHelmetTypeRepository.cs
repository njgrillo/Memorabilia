using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IFullSizeHelmetTypeRepository
    {
        Task Add(Entities.FullSizeHelmetType fullSizeHelmetType, CancellationToken cancellationToken = default);

        Task Delete(Entities.FullSizeHelmetType fullSizeHelmetType, CancellationToken cancellationToken = default);

        Task<Entities.FullSizeHelmetType> Get(int id);

        Task<IEnumerable<Entities.FullSizeHelmetType>> GetAll();

        Task Update(Entities.FullSizeHelmetType fullSizeHelmetType, CancellationToken cancellationToken = default);
    }
}
