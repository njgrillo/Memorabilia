using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces; 

public interface ITeamConferenceRepository : IDomainRepository<TeamConference>
{
    Task<IEnumerable<TeamConference>> GetAll(int? teamId = null);
}
