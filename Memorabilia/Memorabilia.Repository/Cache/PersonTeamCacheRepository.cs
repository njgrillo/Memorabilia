using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Cache;

public class PersonTeamCacheRepository : DomainCacheRepository<PersonTeam>, IPersonTeamRepository
{
    private readonly PersonTeamRepository _personTeamRepository;

    public PersonTeamCacheRepository(DomainContext context, PersonTeamRepository personTeamRepository, IMemoryCache memoryCache)
        : base(context, memoryCache)
    {
        _personTeamRepository = personTeamRepository;
    }

    public Task<IEnumerable<PersonTeam>> GetAll(int franchiseId)
    {
        return GetAll($"PersonTeam_GetAll_{franchiseId}", entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
            return _personTeamRepository.GetAll(franchiseId);
        });
    }
}
