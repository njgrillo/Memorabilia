namespace Memorabilia.Repository.Interfaces;

public interface ITeamLeagueRepository : IDomainRepository<Entity.TeamLeague>
{
    Task<Entity.TeamLeague[]> GetAll(int? teamId = null);
}
