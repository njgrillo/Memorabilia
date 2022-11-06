namespace Memorabilia.Repository.Cache;

public abstract class MemorabiliaCacheRepository<T> : MemorabiliaRepository<T> where T : DomainEntity
{
    protected readonly IMemoryCache MemoryCache;

    public MemorabiliaCacheRepository(MemorabiliaContext context, IMemoryCache memoryCache) : base(context)
    {
        MemoryCache = memoryCache;
    }

    protected Task<IEnumerable<T>> GetAll(string key, Func<ICacheEntry, Task<IEnumerable<T>>> action)
    {
        return MemoryCache.GetOrCreateAsync(key, action);
    }
}
