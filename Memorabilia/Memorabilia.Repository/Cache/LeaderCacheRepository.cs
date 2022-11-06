using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Cache;

public class LeaderCacheRepository : DomainCacheRepository<Leader>, ILeaderRepository
{
    private readonly LeaderRepository _leaderRepository;

    public LeaderCacheRepository(DomainContext context, LeaderRepository leaderRepository, IMemoryCache memoryCache)
        : base(context, memoryCache)
    {
        _leaderRepository = leaderRepository;
    }

    public Task<IEnumerable<Leader>> GetAll(int leaderTypeId)
    {
        return GetAll($"Leader_GetAll_{leaderTypeId}", entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
            return _leaderRepository.GetAll(leaderTypeId);
        });
    }
}
