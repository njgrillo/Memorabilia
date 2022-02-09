using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface ILevelTypeRepository
    {
        Task Add(Entities.LevelType levelType, CancellationToken cancellationToken = default);

        Task Delete(Entities.LevelType levelType, CancellationToken cancellationToken = default);

        Task<Entities.LevelType> Get(int id);

        Task<IEnumerable<Entities.LevelType>> GetAll();

        Task Update(Entities.LevelType levelType, CancellationToken cancellationToken = default);
    }
}
