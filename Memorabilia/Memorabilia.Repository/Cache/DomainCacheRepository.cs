namespace Memorabilia.Repository.Cache;

public abstract class DomainCacheRepository<T>(DomainContext context,
                                               IMemoryCache memoryCache)
    : DomainRepository<T>(context, memoryCache) where T : Domain.Entity
{
    protected readonly IMemoryCache MemoryCache = memoryCache;

    protected Task<T> Get(string key, Func<ICacheEntry, Task<T>> action)
        => MemoryCache.GetOrCreateAsync(key, action);

    protected Task<IEnumerable<T>> GetAll(string key, Func<ICacheEntry, Task<IEnumerable<T>>> action)
        => MemoryCache.GetOrCreateAsync(key, action);
}
