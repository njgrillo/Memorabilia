namespace Memorabilia.Repository.Cache;

public class FranchiseHallOfFameCacheRepository 
    : DomainCacheRepository<FranchiseHallOfFame>, IFranchiseHallOfFameRepository
{
    private readonly FranchiseHallOfFameRepository _franchiseHallOfFameRepository;

    public FranchiseHallOfFameCacheRepository(DomainContext context, 
                                              FranchiseHallOfFameRepository franchiseHallOfFameRepository, 
                                              IMemoryCache memoryCache)
        : base(context, memoryCache)
    {
        _franchiseHallOfFameRepository = franchiseHallOfFameRepository;
    }

    public Task<IEnumerable<FranchiseHallOfFame>> GetAll(int franchiseId)
        => GetAll($"FranchiseHallOfFame_GetAll_{franchiseId}", 
                  entry => 
                  { 
                      entry.SetAbsoluteExpiration(TimeSpan.FromDays(1)); 
                      return _franchiseHallOfFameRepository.GetAll(franchiseId); 
                  });
}
