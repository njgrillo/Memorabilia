namespace Memorabilia.Repository.Cache;

public class FranchiseHallOfFameCacheRepository(DomainContext context,
                                                FranchiseHallOfFameRepository franchiseHallOfFameRepository,
                                                IMemoryCache memoryCache)
    : DomainCacheRepository<FranchiseHallOfFame>(context, memoryCache), IFranchiseHallOfFameRepository
{
    public Task<IEnumerable<FranchiseHallOfFame>> GetAll(int franchiseId)
        => GetAll($"FranchiseHallOfFame_GetAll_{franchiseId}", 
                  entry => 
                  { 
                      entry.SetAbsoluteExpiration(TimeSpan.FromDays(1)); 
                      return franchiseHallOfFameRepository.GetAll(franchiseId); 
                  });
}
