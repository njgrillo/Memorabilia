namespace Memorabilia.Repository.Interfaces;

public interface IPersonTeamRepository
{
    Task<IEnumerable<Entity.PersonTeam>> GetAll(int franchiseId);
}
