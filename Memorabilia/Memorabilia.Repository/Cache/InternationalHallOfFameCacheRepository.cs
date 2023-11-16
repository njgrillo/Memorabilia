namespace Memorabilia.Repository.Cache;

public class InternationalHallOfFameCacheRepository(DomainContext context,
                                                    InternationalHallOfFameRepository internationalHallOfFameRepository,
                                                    IMemoryCache memoryCache)
    : DomainCacheRepository<InternationalHallOfFame>(context, memoryCache), IInternationalHallOfFameRepository
{
    public Task<IEnumerable<InternationalHallOfFame>> GetAll(int? internationalHallOfFameTypeId = null, 
                                                             int? sportLeagueLevelId = null)
        => GetAll($"InternationalHallOfFame_GetAll_{internationalHallOfFameTypeId}_{sportLeagueLevelId}", 
                  entry => 
                  { 
                      entry.SetAbsoluteExpiration(TimeSpan.FromDays(1)); 
                      return internationalHallOfFameRepository.GetAll(internationalHallOfFameTypeId, sportLeagueLevelId); 
                  });
}
