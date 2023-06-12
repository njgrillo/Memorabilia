namespace Memorabilia.Repository.Interfaces;

public interface ILeaderRepository
{
    Task<IEnumerable<Entity.Leader>> GetAll(int leaderTypeId);
}
