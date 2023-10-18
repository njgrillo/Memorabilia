namespace Memorabilia.Repository.Interfaces;

public interface ILeaguePresidentRepository 
    : IDomainRepository<LeaguePresident>
{
    Task<LeaguePresident[]> GetAll(int? sportLeagueLevelId = null, 
                                          int? leagueId = null);
}
