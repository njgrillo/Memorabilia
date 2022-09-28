using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces 
{
    public interface ITeamConferenceRepository
    {
        Task Add(TeamConference teamConference, CancellationToken cancellationToken = default);

        Task Delete(TeamConference teamConference, CancellationToken cancellationToken = default);

        Task<TeamConference> Get(int id);

        Task<IEnumerable<TeamConference>> GetAll(int? teamId = null);

        Task Update(TeamConference teamConference, CancellationToken cancellationToken = default);
    }
}
