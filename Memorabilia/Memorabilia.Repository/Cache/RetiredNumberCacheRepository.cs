namespace Memorabilia.Repository.Cache;

public class RetiredNumberCacheRepository 
    : DomainCacheRepository<RetiredNumber>, IRetiredNumberRepository
{
    private readonly RetiredNumberRepository _retiredNumberRepository;

    public RetiredNumberCacheRepository(DomainContext context, 
                                        RetiredNumberRepository retiredNumberRepository, 
                                        IMemoryCache memoryCache)
        : base(context, memoryCache)
    {
        _retiredNumberRepository = retiredNumberRepository;
    }

    public Task<IEnumerable<RetiredNumber>> GetAll(int franchiseId) 
        => GetAll($"RetiredNumber_GetAll_{franchiseId}", 
                  entry => 
                  { 
                      entry.SetAbsoluteExpiration(TimeSpan.FromDays(1)); 
                      return _retiredNumberRepository.GetAll(franchiseId); 
                  });
}
