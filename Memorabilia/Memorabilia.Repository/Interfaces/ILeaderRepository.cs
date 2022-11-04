using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces;

public interface ILeaderRepository
{
    Task<IEnumerable<Leader>> GetAll(int leaderTypeId);
}
