using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface ITeamDivisionRepository
    {
        Task Add(TeamDivision teamDivision, CancellationToken cancellationToken = default);

        Task Delete(TeamDivision teamDivision, CancellationToken cancellationToken = default);

        Task<TeamDivision> Get(int id);

        Task<IEnumerable<TeamDivision>> GetAll(int? teamId = null);

        Task Update(TeamDivision teamDivision, CancellationToken cancellationToken = default);
    }
}
