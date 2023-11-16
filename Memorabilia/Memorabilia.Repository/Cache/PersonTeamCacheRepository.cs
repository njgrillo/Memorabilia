namespace Memorabilia.Repository.Cache;

public class PersonTeamCacheRepository(DomainContext context,
                                       PersonTeamRepository personTeamRepository,
                                       IMemoryCache memoryCache)
    : DomainCacheRepository<PersonTeam>(context, memoryCache), IPersonTeamRepository
{
    public Task<IEnumerable<PersonTeam>> GetAll(int franchiseId)
        => GetAll($"PersonTeam_GetAll_{franchiseId}", 
                  entry =>
                  {
                      entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
                      return personTeamRepository.GetAll(franchiseId);
                  });
}
