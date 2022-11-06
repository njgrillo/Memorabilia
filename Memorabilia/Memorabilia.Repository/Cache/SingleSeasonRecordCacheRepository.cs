using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Cache;

public class SingleSeasonRecordCacheRepository : DomainCacheRepository<SingleSeasonRecord>, ISingleSeasonRecordRepository
{
    private readonly SingleSeasonRecordRepository _singleSeasonRecordRepository;

    public SingleSeasonRecordCacheRepository(DomainContext context, SingleSeasonRecordRepository singleSeasonRecordRepository, IMemoryCache memoryCache)
        : base(context, memoryCache)
    {
        _singleSeasonRecordRepository = singleSeasonRecordRepository;
    }

    public Task<IEnumerable<SingleSeasonRecord>> GetAll(int sportId)
    {
        return GetAll($"SingleSeasonRecord_GetAll_{sportId}", entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
            return _singleSeasonRecordRepository.GetAll(sportId);
        });
    }
}
