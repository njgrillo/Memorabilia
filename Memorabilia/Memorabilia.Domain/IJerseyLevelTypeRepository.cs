using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IJerseyLevelTypeRepository
    {
        Task Add(Entities.JerseyLevelType jerseyLevelType, CancellationToken cancellationToken = default);

        Task Delete(Entities.JerseyLevelType jerseyLevelType, CancellationToken cancellationToken = default);

        Task<Entities.JerseyLevelType> Get(int id);

        Task<IEnumerable<Entities.JerseyLevelType>> GetAll();

        Task Update(Entities.JerseyLevelType jerseyLevelType, CancellationToken cancellationToken = default);
    }
}
