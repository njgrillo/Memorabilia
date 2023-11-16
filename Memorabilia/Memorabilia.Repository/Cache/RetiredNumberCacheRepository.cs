namespace Memorabilia.Repository.Cache;

public class RetiredNumberCacheRepository(DomainContext context,
                                          RetiredNumberRepository retiredNumberRepository,
                                          IMemoryCache memoryCache)
    : DomainCacheRepository<RetiredNumber>(context, memoryCache), IRetiredNumberRepository
{
    public Task<IEnumerable<RetiredNumber>> GetAll(int franchiseId) 
        => GetAll($"RetiredNumber_GetAll_{franchiseId}", 
                  entry => 
                  { 
                      entry.SetAbsoluteExpiration(TimeSpan.FromDays(1)); 
                      return retiredNumberRepository.GetAll(franchiseId); 
                  });
}
