using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IJerseyNumberTypeRepository
    {
        Task Add(Entities.JerseyNumberType jerseyNumberType, CancellationToken cancellationToken = default);

        Task Delete(Entities.JerseyNumberType jerseyNumberType, CancellationToken cancellationToken = default);

        Task<Entities.JerseyNumberType> Get(int id);

        Task<IEnumerable<Entities.JerseyNumberType>> GetAll();

        Task Update(Entities.JerseyNumberType jerseyNumberType, CancellationToken cancellationToken = default);
    }
}
