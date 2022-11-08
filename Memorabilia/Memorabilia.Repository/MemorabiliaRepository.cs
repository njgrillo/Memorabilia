namespace Memorabilia.Repository;

public class MemorabiliaRepository<T> : BaseRepository<T>, IDomainRepository<T> where T : DomainEntity
{
    private readonly MemorabiliaContext _context;

    public MemorabiliaRepository(MemorabiliaContext context, IMemoryCache memoryCache) : base(context, memoryCache)
    {
        _context = context;
    }

    protected IQueryable<T> Items => _context.Set<T>();

    public virtual async Task Add(T item, CancellationToken cancellationToken = default)
    {
        _context.Add(item);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public void CommitTransaction()
    {
        CommitTransaction(_context);
    }

    public async Task Delete(T item, CancellationToken cancellationToken = default)
    {
        _context.Set<T>().Remove(item);

        await _context.SaveChangesAsync(cancellationToken);
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
        return GetTransaction(_context);
    }

    public void RollbackTransaction()
    {
        RollbackTransaction(_context);
    }

    public async Task Update(T item, CancellationToken cancellationToken = default)
    {
        _context.Set<T>().Update(item);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
