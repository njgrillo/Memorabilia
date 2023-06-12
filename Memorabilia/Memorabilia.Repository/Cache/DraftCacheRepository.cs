namespace Memorabilia.Repository.Cache;

public class DraftCacheRepository 
    : DomainCacheRepository<Entity.Draft>, IDraftRepository
{
    private readonly DraftRepository _draftRepository;

    public DraftCacheRepository(DomainContext context, 
                                DraftRepository draftRepository, 
                                IMemoryCache memoryCache)
        : base(context, memoryCache)
    {
        _draftRepository = draftRepository;
    }

    public Task<IEnumerable<Entity.Draft>> GetAll(int franchiseId)
        => GetAll($"Draft_GetAll_{franchiseId}", 
                  entry => 
                  { 
                      entry.SetAbsoluteExpiration(TimeSpan.FromDays(1)); 
                      return _draftRepository.GetAll(franchiseId); 
                  });
}
