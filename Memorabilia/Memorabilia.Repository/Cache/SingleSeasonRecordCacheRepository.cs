namespace Memorabilia.Repository.Cache;

public class SingleSeasonRecordCacheRepository(DomainContext context,
                                               SingleSeasonRecordRepository singleSeasonRecordRepository,
                                               IMemoryCache memoryCache)
    : DomainCacheRepository<SingleSeasonRecord>(context, memoryCache), ISingleSeasonRecordRepository
{
    public Task<IEnumerable<SingleSeasonRecord>> GetAll(int sportId) 
        => singleSeasonRecordRepository.GetAll(sportId);
}
