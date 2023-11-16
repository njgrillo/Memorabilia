namespace Memorabilia.Repository.Cache;

public class DraftCacheRepository(DomainContext context,
                                  DraftRepository draftRepository,
                                  IMemoryCache memoryCache)
    : DomainCacheRepository<Draft>(context, memoryCache), IDraftRepository
{
    public Task<IEnumerable<Draft>> GetAll(int franchiseId)
        => GetAll($"Draft_GetAll_{franchiseId}", 
                  entry => 
                  { 
                      entry.SetAbsoluteExpiration(TimeSpan.FromDays(1)); 
                      return draftRepository.GetAll(franchiseId); 
                  });
}
