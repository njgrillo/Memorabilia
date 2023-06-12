namespace Memorabilia.Repository.Interfaces;

public interface ITeamRepository : IDomainRepository<Entity.Team>
{
    Task<Entity.Team[]> GetAll(int? franchiseId = null, 
                               int? sportLeagueLevelId = null, 
                               int? sportId = null);

    Task<Entity.Team[]> GetAllCurrentTeams(int? sportId = null);
}
