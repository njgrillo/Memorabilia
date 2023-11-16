namespace Memorabilia.Repository.Cache;

public class PersonCacheRepository(DomainContext context,
                                   PersonRepository personRepository,
                                   IMemoryCache memoryCache)
    : DomainCacheRepository<Person>(context, memoryCache), IPersonRepository
{
    public override async Task Add(Person person, 
                                   CancellationToken cancellationToken = default)
    {
        RemoveFromCache($"Person_GetAll");

        await personRepository.Add(person, cancellationToken);
    }

    public async Task<Person> Get(string displayName = null, 
                                  string profileName = null, 
                                  string legalName = null)
        => await personRepository.Get(displayName, profileName, legalName);

    public Task<IEnumerable<Person>> GetAll(int? sportId = null, 
                                            int? sportLeagueLevelId = null)
        => sportId == null && 
           sportLeagueLevelId == null
                ? GetAll($"Person_GetAll", 
                         entry =>
                         {
                             entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
                             return personRepository.GetAll();
                         })
                : personRepository.GetAll(sportId, sportLeagueLevelId);

    public Task<Person[]> GetAll(Dictionary<string, object> parameters)
        => personRepository.GetAll(parameters);

    public Task<Person[]> GetAll(int teamId, int year)
        => personRepository.GetAll(teamId, year);

    public Task<Person[]> GetAllHallOfFamers(int sportLeagueLevelId, int? year)
        => personRepository.GetAllHallOfFamers(sportLeagueLevelId, year);

    public Task<Person[]> GetMostRecent()
        => personRepository.GetMostRecent();
}
