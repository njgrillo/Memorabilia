namespace Memorabilia.Repository.Interfaces;

public interface ILeaguePresidentRepository 
    : IDomainRepository<Entity.LeaguePresident>
{
    Task<Entity.LeaguePresident[]> GetAll(int? sportLeagueLevelId = null, 
                                          int? leagueId = null);
}
