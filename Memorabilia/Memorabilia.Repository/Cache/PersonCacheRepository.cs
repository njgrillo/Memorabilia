﻿namespace Memorabilia.Repository.Cache;

public class PersonCacheRepository 
    : DomainCacheRepository<Person>, IPersonRepository
{
    private readonly PersonRepository _personRepository;

    public PersonCacheRepository(DomainContext context, 
                                 PersonRepository personRepository, 
                                 IMemoryCache memoryCache) 
        : base(context, memoryCache) 
    {
        _personRepository = personRepository;
    }

    public override async Task Add(Person person, 
                                   CancellationToken cancellationToken = default)
    {
        RemoveFromCache($"Person_GetAll");

        await _personRepository.Add(person, cancellationToken);
    }

    public async Task<Person> Get(string displayName = null, 
                                         string profileName = null, 
                                         string legalName = null)
        => await _personRepository.Get(displayName, profileName, legalName);

    public Task<IEnumerable<Person>> GetAll(int? sportId = null, 
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

    public Task<Person[]> GetAll(Dictionary<string, object> parameters)
        => _personRepository.GetAll(parameters);

    public Task<Person[]> GetAll(int teamId, int year)
        => _personRepository.GetAll(teamId, year);

    public Task<Person[]> GetAllHallOfFamers(int sportLeagueLevelId, int? year)
        => _personRepository.GetAllHallOfFamers(sportLeagueLevelId, year);

    public Task<Person[]> GetMostRecent()
        => _personRepository.GetMostRecent();
}
