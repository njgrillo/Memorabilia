namespace Memorabilia.Repository.Cache;

public class InternationalHallOfFameCacheRepository 
    : DomainCacheRepository<Entity.InternationalHallOfFame>, IInternationalHallOfFameRepository
{
    private readonly InternationalHallOfFameRepository _internationalHallOfFameRepository;

    public InternationalHallOfFameCacheRepository(DomainContext context, 
                                                  InternationalHallOfFameRepository internationalHallOfFameRepository, 
                                                  IMemoryCache memoryCache)
        : base(context, memoryCache)
    {
        _internationalHallOfFameRepository = internationalHallOfFameRepository;
    }

    public Task<IEnumerable<Entity.InternationalHallOfFame>> GetAll(int? internationalHallOfFameTypeId = null, 
                                                                    int? sportLeagueLevelId = null)
        => GetAll($"InternationalHallOfFame_GetAll_{internationalHallOfFameTypeId}_{sportLeagueLevelId}", 
                  entry => 
                  { 
                      entry.SetAbsoluteExpiration(TimeSpan.FromDays(1)); 
                      return _internationalHallOfFameRepository.GetAll(internationalHallOfFameTypeId, sportLeagueLevelId); 
                  });
}
