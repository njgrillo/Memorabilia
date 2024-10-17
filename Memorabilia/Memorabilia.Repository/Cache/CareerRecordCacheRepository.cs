namespace Memorabilia.Repository.Cache;

public class CareerRecordCacheRepository(DomainContext context,
                                         CareerRecordRepository careerRecordRepository,
                                         IMemoryCache memoryCache)
    : DomainCacheRepository<CareerRecord>(context, memoryCache), ICareerRecordRepository
{
    public Task<IEnumerable<CareerRecord>> GetAll(int sportId)
        => careerRecordRepository.GetAll(sportId);
}
