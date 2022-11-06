using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Cache;

public class PersonCacheRepository : DomainCacheRepository<Person>, IPersonRepository
{
    private readonly PersonRepository _personRepository;

    public PersonCacheRepository(DomainContext context, PersonRepository personRepository, IMemoryCache memoryCache) 
        : base(context, memoryCache) 
    {
        _personRepository = personRepository;
    }

    public override Task<Person> Get(int id)
    {
        return Get($"Person_Get_{id}", entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
            return _personRepository.Get(id);
        });
    }

    public Task<IEnumerable<Person>> GetAll(int? sportId = null, int? sportLeagueLevelId = null)
    {
        return GetAll($"Person_GetAll_{sportId ?? 0}_{sportLeagueLevelId ?? 0}", entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
            return _personRepository.GetAll(sportId, sportLeagueLevelId);
        });
    }
}
