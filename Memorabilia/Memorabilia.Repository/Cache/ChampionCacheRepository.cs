namespace Memorabilia.Repository.Cache;

public class ChampionCacheRepository(DomainContext context,
                                     ChampionRepository championRepository,
                                     IMemoryCache memoryCache)
    : DomainCacheRepository<Champion>(context, memoryCache), IChampionRepository
{
    public Task<IEnumerable<Champion>> GetAll(int championTypeId)
        => GetAll($"Champion_GetAll_{championTypeId}", 
                  entry => 
                  { 
                      entry.SetAbsoluteExpiration(TimeSpan.FromDays(1)); 
                      return championRepository.GetAll(championTypeId); 
                  });
}
