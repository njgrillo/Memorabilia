using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IBaseballTypeRepository
    {
        Task Add(Entities.BaseballType baseballType, CancellationToken cancellationToken = default);

        Task Delete(Entities.BaseballType baseballType, CancellationToken cancellationToken = default);

        Task<Entities.BaseballType> Get(int id);

        Task<IEnumerable<Entities.BaseballType>> GetAll();

        Task Update(Entities.BaseballType baseballType, CancellationToken cancellationToken = default);
    }
}
