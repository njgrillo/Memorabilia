namespace Memorabilia.Repository.Cache;

public class PersonAwardCacheRepository(DomainContext context,
                                        PersonAwardRepository personAwardRepository,
                                        IMemoryCache memoryCache)
    : DomainCacheRepository<PersonAward>(context, memoryCache), IPersonAwardRepository
{
    public Task<IEnumerable<PersonAward>> GetAll(int awardTypeId)
        => GetAll($"PersonAward_GetAll_{awardTypeId}", 
                  entry => 
                  { 
                      entry.SetAbsoluteExpiration(TimeSpan.FromDays(1)); 
                      return personAwardRepository.GetAll(awardTypeId); 
                  });
}
