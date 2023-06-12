namespace Memorabilia.Repository.Cache;

public class PersonCacheRepository 
    : DomainCacheRepository<Entity.Person>, IPersonRepository
{
    private readonly PersonRepository _personRepository;

    public PersonCacheRepository(DomainContext context, 
                                 PersonRepository personRepository, 
                                 IMemoryCache memoryCache) 
        : base(context, memoryCache) 
    {
        _personRepository = personRepository;
    }

    public override async Task Add(Entity.Person person, 
                                   CancellationToken cancellationToken = default)
    {
        RemoveFromCache($"Person_GetAll");

        await _personRepository.Add(person, cancellationToken);
    }

    public Task<IEnumerable<Entity.Person>> GetAll(int? sportId = null, 
                                                   int? sportLeagueLevelId = null)
        => sportId == null && 
           sportLeagueLevelId == null
                ? GetAll($"Person_GetAll", 
                         entry =>
                         {
                             entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
                             return _personRepository.GetAll();
                         })
                : _personRepository.GetAll(sportId, sportLeagueLevelId);

    public Task<Entity.Person[]> GetAll(Dictionary<string, object> parameters)
        => _personRepository.GetAll(parameters);

    public Task<Entity.Person[]> GetAll(int teamId, int year)
        => _personRepository.GetAll(teamId, year);

    public Task<Entity.Person[]> GetAllHallOfFamers(int sportLeagueLevelId, int? year)
        => _personRepository.GetAllHallOfFamers(sportLeagueLevelId, year);

    public Task<Entity.Person[]> GetMostRecent()
        => _personRepository.GetMostRecent();
}
