namespace Memorabilia.Repository;

public abstract class BaseRepository<T> : IBaseRepository where T : DomainEntity
{
    private readonly IMemoryCache _memoryCache;

    public BaseRepository(DomainContext context)
    {
        context.Set<T>().Where(t => 1 == 0).Load();
    }

    public BaseRepository(MemorabiliaContext context, IMemoryCache memoryCache)
    {
        context.Set<T>().Where(t => 1 == 0).Load();
        _memoryCache = memoryCache;
    }

    public void CommitTransaction(DbContext context)
    {
        context.CommitTransaction();
    }

    protected Task<T> GetFromCache(string key, Func<ICacheEntry, Task<T>> action)
    {
        return _memoryCache.GetOrCreateAsync(key, action);
    }

    public Task<IEnumerable<T>> GetFromCache(string key, Func<ICacheEntry, Task<IEnumerable<T>>> action)
    {
        return _memoryCache.GetOrCreateAsync(key, action);
    }

    public IDbContextTransaction GetTransaction(DbContext context)
    {
        return context.Database.CurrentTransaction ?? context.BeginTransaction();
    }

    protected void RemoveFromCache(string key)
    {
        _memoryCache.Remove(key);
    }

    public void RollbackTransaction(DbContext context)
    {
        context.RollbackTransaction();
    }
}
