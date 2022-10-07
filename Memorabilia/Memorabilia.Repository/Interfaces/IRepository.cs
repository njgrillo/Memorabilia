namespace Memorabilia.Repository.Interfaces;

public interface IRepository<T> where T : class
{
    Task Add(T entity, CancellationToken cancellationToken = default);

    Task Delete(T entity, CancellationToken cancellationToken = default);

    Task<T> Get(int id);

    Task<IEnumerable<T>> GetAll();

    Task Update(T entity, CancellationToken cancellationToken = default);
}
