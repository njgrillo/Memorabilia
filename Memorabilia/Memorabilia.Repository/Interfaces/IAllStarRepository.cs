namespace Memorabilia.Repository.Interfaces;

public interface IAllStarRepository
{
    Task<IEnumerable<Entity.AllStar>> GetAll(int year, Constant.Sport sport = null);
}
