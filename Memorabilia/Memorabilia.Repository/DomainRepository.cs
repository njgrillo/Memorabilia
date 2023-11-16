namespace Memorabilia.Repository;

public class DomainRepository<T>(DomainContext context, IMemoryCache memoryCache)
    : BaseRepository<T>(context, memoryCache), IDomainRepository<T> where T : Domain.Entity
{
    protected readonly DomainContext Context = context;

    protected IQueryable<T> Items 
        => Context.Set<T>();

    public virtual async Task Add(T item, CancellationToken cancellationToken = default)
    {
        Context.Add(item);

        await Context.SaveChangesAsync(cancellationToken);
    }

    public void CommitTransaction()
    {
        CommitTransaction(Context);
    }

    public async Task Delete(T item, CancellationToken cancellationToken = default)
    {
        Context.Set<T>().Remove(item);

        await Context.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task<T> Get(int id)
        => await Items.SingleOrDefaultAsync(item => item.Id == id);

    public async Task<T[]> GetAll()
        => await Items.ToArrayAsync();

    public IDbContextTransaction GetTransaction()
        => GetTransaction(Context);

    public void RollbackTransaction()
    {
        RollbackTransaction(Context);
    }

    public async Task Update(T item, CancellationToken cancellationToken = default)
    {
        Context.Set<T>().Update(item);

        await Context.SaveChangesAsync(cancellationToken);
    }
}
