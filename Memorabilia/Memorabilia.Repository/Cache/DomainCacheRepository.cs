namespace Memorabilia.Repository.Cache;

public abstract class DomainCacheRepository<T> 
    : DomainRepository<T> where T : DomainIdEntity
{
    protected readonly IMemoryCache MemoryCache;

    public DomainCacheRepository(DomainContext context, 
                                 IMemoryCache memoryCache) 
        : base(context, memoryCache)
    {
        MemoryCache = memoryCache;
    }

    protected Task<T> Get(string key, Func<ICacheEntry, Task<T>> action)
        => MemoryCache.GetOrCreateAsync(key, action);

    protected Task<IEnumerable<T>> GetAll(string key, Func<ICacheEntry, Task<IEnumerable<T>>> action)
        => MemoryCache.GetOrCreateAsync(key, action);
}
