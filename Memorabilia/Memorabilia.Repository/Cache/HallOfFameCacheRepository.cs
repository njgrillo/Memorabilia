namespace Memorabilia.Repository.Cache;

public class HallOfFameCacheRepository(DomainContext context,
                                       HallOfFameRepository hallOfFameRepository,
                                       IMemoryCache memoryCache)
    : DomainCacheRepository<HallOfFame>(context, memoryCache), IHallOfFameRepository
{
    public Task<IEnumerable<HallOfFame>> GetAll(int? sportLeagueLevelId = null, 
                                                       int? inductionYear = null)
        => GetAll($"HallOfFame_GetAll_{sportLeagueLevelId}_{inductionYear}", 
                  entry =>
                  {
                      entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
                      return hallOfFameRepository.GetAll(sportLeagueLevelId, inductionYear);
                  });
}
