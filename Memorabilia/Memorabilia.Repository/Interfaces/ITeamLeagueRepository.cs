namespace Memorabilia.Repository.Interfaces;

public interface ITeamLeagueRepository : IDomainRepository<TeamLeague>
{
    Task<TeamLeague[]> GetAll(int? teamId = null);
}
