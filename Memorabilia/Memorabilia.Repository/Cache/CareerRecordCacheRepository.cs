namespace Memorabilia.Repository.Cache;

public class CareerRecordCacheRepository 
    : DomainCacheRepository<Entity.CareerRecord>, ICareerRecordRepository
{
    private readonly CareerRecordRepository _careerRecordRepository;

    public CareerRecordCacheRepository(DomainContext context, 
                                      CareerRecordRepository careerRecordRepository, 
                                      IMemoryCache memoryCache)
        : base(context, memoryCache)
    {
        _careerRecordRepository = careerRecordRepository;
    }

    public Task<IEnumerable<Entity.CareerRecord>> GetAll(int sportId)
        => GetAll($"CareerRecord_GetAll_{sportId}", 
                  entry =>
                  {
                      entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
                      return _careerRecordRepository.GetAll(sportId);
                  });
}
