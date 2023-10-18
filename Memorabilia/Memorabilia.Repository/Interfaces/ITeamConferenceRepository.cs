namespace Memorabilia.Repository.Interfaces; 

public interface ITeamConferenceRepository : IDomainRepository<TeamConference>
{
    Task<TeamConference[]> GetAll(int? teamId = null);
}
