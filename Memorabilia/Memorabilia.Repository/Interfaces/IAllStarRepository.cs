namespace Memorabilia.Repository.Interfaces;

public interface IAllStarRepository
{
    Task<AllStar[]> GetAll();

    Task<IEnumerable<AllStar>> GetAll(int year, Constant.Sport sport = null);

    Task<IEnumerable<AllStar>> GetAll(int sportId, int? year = null);
}
