namespace Memorabilia.Repository.Interfaces;

public interface ITeamRepository : IDomainRepository<Team>
{
    Task<Team[]> GetAll(int? franchiseId = null, 
                               int? sportLeagueLevelId = null, 
                               int? sportId = null);

    Task<Team[]> GetAllCurrentTeams(int? sportId = null);
}
