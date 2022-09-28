using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IFootballTypeRepository
    {
        Task Add(FootballType footballType, CancellationToken cancellationToken = default);

        Task Delete(FootballType footballType, CancellationToken cancellationToken = default);

        Task<FootballType> Get(int id);

        Task<IEnumerable<FootballType>> GetAll();

        Task Update(FootballType footballType, CancellationToken cancellationToken = default);
    }
}
