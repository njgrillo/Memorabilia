namespace Memorabilia.Repository.Interfaces;

public interface IDomainRepository<T> 
    : ITransaction where T : Domain.Entity
{
    Task Add(T item, CancellationToken cancellationToken = default);

    Task Delete(T item, CancellationToken cancellationToken = default);

    Task<T> Get(int id);

    Task<T[]> GetAll();

    Task Update(T item, CancellationToken cancellationToken = default);
}
