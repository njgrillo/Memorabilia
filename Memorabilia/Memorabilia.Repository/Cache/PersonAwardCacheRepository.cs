using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Cache;

public class PersonAwardCacheRepository : DomainCacheRepository<PersonAward>, IPersonAwardRepository
{
    private readonly PersonAwardRepository _personAwardRepository;

    public PersonAwardCacheRepository(DomainContext context, PersonAwardRepository personAwardRepository, IMemoryCache memoryCache)
        : base(context, memoryCache)
    {
        _personAwardRepository = personAwardRepository;
    }

    public Task<IEnumerable<PersonAward>> GetAll(int awardTypeId)
    {
        return GetAll($"PersonAward_GetAll_{awardTypeId}", entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
            return _personAwardRepository.GetAll(awardTypeId);
        });
    }
}
