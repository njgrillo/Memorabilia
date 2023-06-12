namespace Memorabilia.Repository.Cache;

public class AllStarCacheRepository 
    : DomainCacheRepository<Entity.AllStar>, IAllStarRepository
{
    private readonly AllStarRepository _allStarRepository;

    public AllStarCacheRepository(DomainContext context, 
                                  AllStarRepository allStarRepository, 
                                  IMemoryCache memoryCache)
        : base(context, memoryCache)
    {
        _allStarRepository = allStarRepository;
    }

    public Task<IEnumerable<Entity.AllStar>> GetAll(int year, Constant.Sport sport = null)
        => GetAll($"AllStar_GetAll_{year}_{sport?.Id ?? 0}",
                  entry =>
                  {
                      entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
                      return _allStarRepository.GetAll(year, sport);
                  });
}
