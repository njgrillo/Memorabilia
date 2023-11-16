namespace Memorabilia.Repository.Cache;

public class LeaderCacheRepository(DomainContext context,
                                   LeaderRepository leaderRepository,
                                   IMemoryCache memoryCache)
    : DomainCacheRepository<Leader>(context, memoryCache), ILeaderRepository
{
    public Task<IEnumerable<Leader>> GetAll(int leaderTypeId)
        => GetAll($"Leader_GetAll_{leaderTypeId}",
                  entry =>
                  {
                      entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
                      return leaderRepository.GetAll(leaderTypeId);
                  });
}
