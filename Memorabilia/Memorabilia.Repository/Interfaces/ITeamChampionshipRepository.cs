using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface ITeamChampionshipRepository
    {
        Task Add(Champion champion, CancellationToken cancellationToken = default);

        Task Delete(Champion champion, CancellationToken cancellationToken = default);

        Task<Champion> Get(int id);

        Task<IEnumerable<Champion>> GetAll(int? teamId = null);

        Task Update(Champion champion, CancellationToken cancellationToken = default);
    }
}
