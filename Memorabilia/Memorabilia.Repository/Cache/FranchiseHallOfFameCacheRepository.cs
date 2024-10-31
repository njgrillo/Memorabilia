namespace Memorabilia.Repository.Cache;

public class FranchiseHallOfFameCacheRepository(DomainContext context,
                                                FranchiseHallOfFameRepository franchiseHallOfFameRepository,
                                                IMemoryCache memoryCache)
    : DomainCacheRepository<FranchiseHallOfFame>(context, memoryCache), IFranchiseHallOfFameRepository
{
    public Task<IEnumerable<FranchiseHallOfFame>> GetAll(int franchiseId)
        => franchiseHallOfFameRepository.GetAll(franchiseId);   
}
