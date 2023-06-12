namespace Memorabilia.Repository.Interfaces;

public interface ITeamDivisionRepository 
    : IDomainRepository<Entity.TeamDivision>
{
    Task<Entity.TeamDivision[]> GetAll(int? teamId = null);
}
