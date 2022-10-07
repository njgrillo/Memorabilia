namespace Memorabilia.Repository.Interfaces;

public interface IDomainRepository<T> : ITransaction where T : DomainEntity
{
    Task Add(T item, CancellationToken cancellationToken = default);

    Task Delete(T item, CancellationToken cancellationToken = default);

    Task<T> Get(int id);

    Task<IEnumerable<T>> GetAll();

    Task Update(T item, CancellationToken cancellationToken = default);
}
