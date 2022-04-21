using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IChampionTypeRepository
    {
        Task Add(ChampionType championType, CancellationToken cancellationToken = default);

        Task Delete(ChampionType championType, CancellationToken cancellationToken = default);

        Task<ChampionType> Get(int id);

        Task<IEnumerable<ChampionType>> GetAll();

        Task Update(ChampionType championType, CancellationToken cancellationToken = default);
    }
}
