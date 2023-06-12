namespace Memorabilia.Repository.Interfaces;

public interface IChampionRepository
{
    Task<IEnumerable<Entity.Champion>> GetAll(int championTypeId);
}
