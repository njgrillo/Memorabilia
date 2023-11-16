namespace Memorabilia.Repository.Cache;

public class CareerRecordCacheRepository(DomainContext context,
                                         CareerRecordRepository careerRecordRepository,
                                         IMemoryCache memoryCache)
    : DomainCacheRepository<CareerRecord>(context, memoryCache), ICareerRecordRepository
{
    public Task<IEnumerable<CareerRecord>> GetAll(int sportId)
        => GetAll($"CareerRecord_GetAll_{sportId}", 
                  entry =>
                  {
                      entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
                      return careerRecordRepository.GetAll(sportId);
                  });
}
