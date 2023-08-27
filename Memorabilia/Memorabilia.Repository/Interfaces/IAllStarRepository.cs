namespace Memorabilia.Repository.Interfaces;

public interface IAllStarRepository
{
    Task<Entity.AllStar[]> GetAll();

    Task<IEnumerable<Entity.AllStar>> GetAll(int year, Constant.Sport sport = null);
}
