using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface ILevelTypeRepository
    {
        Task Add(LevelType levelType, CancellationToken cancellationToken = default);

        Task Delete(LevelType levelType, CancellationToken cancellationToken = default);

        Task<LevelType> Get(int id);

        Task<IEnumerable<LevelType>> GetAll();

        Task Update(LevelType levelType, CancellationToken cancellationToken = default);
    }
}
