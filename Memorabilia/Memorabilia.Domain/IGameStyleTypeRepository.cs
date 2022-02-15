using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IGameStyleTypeRepository
    {
        Task Add(Entities.GameStyleType gameStyleType, CancellationToken cancellationToken = default);

        Task Delete(Entities.GameStyleType gameStyleType, CancellationToken cancellationToken = default);

        Task<Entities.GameStyleType> Get(int id);

        Task<IEnumerable<Entities.GameStyleType>> GetAll();

        Task Update(Entities.GameStyleType gameStyleType, CancellationToken cancellationToken = default);
    }
}
