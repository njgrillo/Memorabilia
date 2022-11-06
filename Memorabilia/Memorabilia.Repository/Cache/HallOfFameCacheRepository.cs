using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Cache;

public class HallOfFameCacheRepository : DomainCacheRepository<HallOfFame>, IHallOfFameRepository
{
    private readonly HallOfFameRepository _hallOfFameRepository;

    public HallOfFameCacheRepository(DomainContext context, HallOfFameRepository hallOfFameRepository, IMemoryCache memoryCache)
        : base(context, memoryCache)
    {
        _hallOfFameRepository = hallOfFameRepository;
    }

    public Task<IEnumerable<HallOfFame>> GetAll(int? sportLeagueLevelId = null, int? inductionYear = null)
    {
        return GetAll($"HallOfFame_GetAll_{sportLeagueLevelId}_{inductionYear}", entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
            return _hallOfFameRepository.GetAll(sportLeagueLevelId, inductionYear);
        });
    }
}
