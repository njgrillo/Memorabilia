namespace Memorabilia.Repository;

public class MemorabiliaRepository<T> 
    : BaseRepository<T>, IDomainRepository<T> where T : DomainEntity
{
    protected readonly MemorabiliaContext Context;

    public MemorabiliaRepository(MemorabiliaContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache)
    {
        Context = context;
    }

    protected IQueryable<T> Items => Context.Set<T>();

    public virtual async Task Add(T item, CancellationToken cancellationToken = default)
    {
        Context.Add(item);

        await Context.SaveChangesAsync(cancellationToken);
    }

    public void CommitTransaction()
    {
        CommitTransaction(Context);
    }

    public virtual async Task Delete(T item, CancellationToken cancellationToken = default)
    {
        Context.Set<T>().Remove(item);

        await Context.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task<T> Get(int id)
    {
        return await Items.SingleOrDefaultAsync(item => item.Id == id);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await Items.ToListAsync();
    }

    public IDbContextTransaction GetTransaction()
    {
        return GetTransaction(Context);
    }

    public void RollbackTransaction()
    {
        RollbackTransaction(Context);
    }

    public virtual async Task Update(T item, CancellationToken cancellationToken = default)
    {
        Context.Set<T>().Update(item);

        await Context.SaveChangesAsync(cancellationToken);
    }
}
