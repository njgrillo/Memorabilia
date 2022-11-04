using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces;

public interface IAllStarRepository
{
    Task<IEnumerable<AllStar>> GetAll(int year);
}
