namespace Memorabilia.Repository.Cache;

public class SingleSeasonRecordCacheRepository(DomainContext context,
                                               SingleSeasonRecordRepository singleSeasonRecordRepository,
                                               IMemoryCache memoryCache)
    : DomainCacheRepository<SingleSeasonRecord>(context, memoryCache), ISingleSeasonRecordRepository
{
    public Task<IEnumerable<SingleSeasonRecord>> GetAll(int sportId) 
        => GetAll($"SingleSeasonRecord_GetAll_{sportId}", 
                  entry => 
                  { 
                      entry.SetAbsoluteExpiration(TimeSpan.FromDays(1)); 
                      return singleSeasonRecordRepository.GetAll(sportId); 
                  });
}
