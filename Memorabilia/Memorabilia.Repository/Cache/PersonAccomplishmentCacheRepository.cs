using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Cache;

public class PersonAccomplishmentCacheRepository : DomainCacheRepository<PersonAccomplishment>, IPersonAccomplishmentRepository
{
    private readonly PersonAccomplishmentRepository _personAccomplishmentRepository;

    public PersonAccomplishmentCacheRepository(DomainContext context, 
        PersonAccomplishmentRepository personAccomplishmentRepository, 
        IMemoryCache memoryCache)
        : base(context, memoryCache)
    {
        _personAccomplishmentRepository = personAccomplishmentRepository;
    }

    public override async Task Add(PersonAccomplishment item, CancellationToken cancellationToken = default)
    {
        RemoveFromCache($"PersonAccomplishment_GetAll_{item.AccomplishmentTypeId}");

        await _personAccomplishmentRepository.Add(item, cancellationToken);
    }

    public Task<IEnumerable<PersonAccomplishment>> GetAll(int accomplishmentTypeId)
    {
        return GetAll($"PersonAccomplishment_GetAll_{accomplishmentTypeId}", entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
            return _personAccomplishmentRepository.GetAll(accomplishmentTypeId);
        });
    }
}
