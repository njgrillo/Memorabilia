namespace Memorabilia.Repository.Interfaces;

public interface IHistoryRepository<T> where T : Domain.Entity
{
    Task<T> Get(int id);

    Task<T[]> GetAll();
}
