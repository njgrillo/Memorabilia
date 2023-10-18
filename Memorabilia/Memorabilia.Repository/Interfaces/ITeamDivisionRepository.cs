namespace Memorabilia.Repository.Interfaces;

public interface ITeamDivisionRepository 
    : IDomainRepository<TeamDivision>
{
    Task<TeamDivision[]> GetAll(int? teamId = null);
}
