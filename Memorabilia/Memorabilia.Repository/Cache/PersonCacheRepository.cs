﻿using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Cache;

public class PersonCacheRepository : DomainCacheRepository<Person>, IPersonRepository
{
    private readonly PersonRepository _personRepository;

    public PersonCacheRepository(DomainContext context, PersonRepository personRepository, IMemoryCache memoryCache) 
        : base(context, memoryCache) 
    {
        _personRepository = personRepository;
    }

    public override async Task Add(Person person, CancellationToken cancellationToken = default)
    {
        RemoveFromCache($"Person_GetAll");

        await _personRepository.Add(person, cancellationToken);
    }

    public Task<IEnumerable<Person>> GetAll(int? sportId = null, int? sportLeagueLevelId = null)
    {
        if (sportId == null && sportLeagueLevelId == null)
        {
            return GetAll($"Person_GetAll", entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
                return _personRepository.GetAll();
            });
        }

        return _personRepository.GetAll(sportId, sportLeagueLevelId);
    }
}
