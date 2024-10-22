namespace Memorabilia.Repository.Interfaces;

public interface ILeaderRepository
{
    Task<IEnumerable<Leader>> GetAll(int leaderTypeId);

    Task<IEnumerable<Leader>> GetAll(int sportId, int year);
}
