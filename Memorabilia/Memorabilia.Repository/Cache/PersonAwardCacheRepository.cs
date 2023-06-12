namespace Memorabilia.Repository.Cache;

public class PersonAwardCacheRepository 
    : DomainCacheRepository<Entity.PersonAward>, IPersonAwardRepository
{
    private readonly PersonAwardRepository _personAwardRepository;

    public PersonAwardCacheRepository(DomainContext context, 
                                      PersonAwardRepository personAwardRepository, 
                                      IMemoryCache memoryCache)
        : base(context, memoryCache)
    {
        _personAwardRepository = personAwardRepository;
    }

    public Task<IEnumerable<Entity.PersonAward>> GetAll(int awardTypeId)
        => GetAll($"PersonAward_GetAll_{awardTypeId}", 
                  entry => 
                  { 
                      entry.SetAbsoluteExpiration(TimeSpan.FromDays(1)); 
                      return _personAwardRepository.GetAll(awardTypeId); 
                  });
}
