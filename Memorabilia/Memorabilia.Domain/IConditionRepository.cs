using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IConditionRepository
    {
        Task Add(Entities.Condition condition, CancellationToken cancellationToken = default);

        Task Delete(Entities.Condition condition, CancellationToken cancellationToken = default);

        Task<Entities.Condition> Get(int id);

        Task<IEnumerable<Entities.Condition>> GetAll();

        Task Update(Entities.Condition condition, CancellationToken cancellationToken = default);
    }
}
