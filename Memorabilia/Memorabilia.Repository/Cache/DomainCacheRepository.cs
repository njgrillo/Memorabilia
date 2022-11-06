namespace Memorabilia.Repository.Cache;

public abstract class DomainCacheRepository<T> : DomainRepository<T> where T : DomainEntity
{
    protected readonly IMemoryCache MemoryCache;

    public DomainCacheRepository(DomainContext context, IMemoryCache memoryCache) : base(context)
    {
        MemoryCache = memoryCache;
    }

    protected Task<T> Get(string key, Func<ICacheEntry, Task<T>> action)
    {
        return MemoryCache.GetOrCreateAsync(key, action);
    }

    protected Task<IEnumerable<T>> GetAll(string key, Func<ICacheEntry, Task<IEnumerable<T>>> action)
    {
        return MemoryCache.GetOrCreateAsync(key, action);
    }
}
