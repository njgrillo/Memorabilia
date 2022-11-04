using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces;

public interface IChampionRepository
{
    Task<IEnumerable<Champion>> GetAll(int championTypeId);
}
