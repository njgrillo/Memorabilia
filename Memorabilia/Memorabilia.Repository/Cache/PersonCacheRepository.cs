namespace Memorabilia.Repository.Cache;

public class PersonCacheRepository(DomainContext context,
                                   PersonRepository personRepository,
                                   IMemoryCache memoryCache)
    : DomainCacheRepository<Person>(context, memoryCache), IPersonRepository
{
    public override async Task Add(
        Person person, 
        CancellationToken cancellationToken = default
        )
    {
        RemoveFromCache($"Person_GetAll");

        await personRepository.Add(person, cancellationToken);
    }

    public Task<IEnumerable<Person>> GetAll(
        int? sportId = null, 
        int? sportLeagueLevelId = null,
        int? userId = null
        )
        => sportId == null && 
           sportLeagueLevelId == null && 
           userId == null
                ? GetAll($"Person_GetAll", 
                         entry =>
                         {
                             entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
                             return personRepository.GetAll();
                         })
                : personRepository.GetAll(sportId, sportLeagueLevelId, userId);

    public Task<Person[]> GetAll(Dictionary<string, object> parameters, int userId)
        => personRepository.GetAll(parameters, userId);

    public Task<Person[]> GetAll(int teamId, int year, int userId)
        => personRepository.GetAll(teamId, year, userId);

    public Task<Person[]> GetAll(int[] ids)
        => personRepository.GetAll(ids);

    public Task<Person[]> GetAllHallOfFamers(int sportLeagueLevelId, int? year)
        => personRepository.GetAllHallOfFamers(sportLeagueLevelId, year);

    public Task<PagedResult<Person>> GetAllNicknames(
        PageInfo pageInfo, 
        int? sportId = null, 
        string filter = null
        )
        => personRepository.GetAllNicknames(pageInfo, sportId, filter);

    public Task<Person[]> GetMostRecent()
        => personRepository.GetMostRecent();
}
