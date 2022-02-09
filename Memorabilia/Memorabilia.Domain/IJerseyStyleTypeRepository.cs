using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IJerseyStyleTypeRepository
    {
        Task Add(Entities.JerseyStyleType jerseyStyleType, CancellationToken cancellationToken = default);

        Task Delete(Entities.JerseyStyleType jerseyStyleType, CancellationToken cancellationToken = default);

        Task<Entities.JerseyStyleType> Get(int id);

        Task<IEnumerable<Entities.JerseyStyleType>> GetAll();

        Task Update(Entities.JerseyStyleType jerseyStyleType, CancellationToken cancellationToken = default);
    }
}
