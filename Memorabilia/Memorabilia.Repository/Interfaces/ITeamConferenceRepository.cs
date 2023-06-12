namespace Memorabilia.Repository.Interfaces; 

public interface ITeamConferenceRepository : IDomainRepository<Entity.TeamConference>
{
    Task<Entity.TeamConference[]> GetAll(int? teamId = null);
}
