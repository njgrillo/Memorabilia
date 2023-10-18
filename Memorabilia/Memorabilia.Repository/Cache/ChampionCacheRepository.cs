namespace Memorabilia.Repository.Cache;

public class ChampionCacheRepository 
    : DomainCacheRepository<Champion>, IChampionRepository
{
    private readonly ChampionRepository _championRepository;

    public ChampionCacheRepository(DomainContext context, 
                                   ChampionRepository championRepository, 
                                   IMemoryCache memoryCache)
        : base(context, memoryCache)
    {
        _championRepository = championRepository;
    }

    public Task<IEnumerable<Champion>> GetAll(int championTypeId)
        => GetAll($"Champion_GetAll_{championTypeId}", 
                  entry => 
                  { 
                      entry.SetAbsoluteExpiration(TimeSpan.FromDays(1)); 
                      return _championRepository.GetAll(championTypeId); 
                  });
}
