namespace Memorabilia.Repository.Cache;

public class AllStarCacheRepository(DomainContext context,
                                    AllStarRepository allStarRepository,
                                    IMemoryCache memoryCache)
    : DomainCacheRepository<AllStar>(context, memoryCache), IAllStarRepository
{
    public Task<IEnumerable<AllStar>> GetAll(int year, Constant.Sport sport = null)
        => GetAll($"AllStar_GetAll_{year}_{sport?.Id ?? 0}",
                  entry =>
                  {
                      entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
                      return allStarRepository.GetAll(year, sport);
                  });
}
