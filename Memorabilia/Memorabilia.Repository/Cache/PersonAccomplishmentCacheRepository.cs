using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Cache;

public class PersonAccomplishmentCacheRepository : DomainCacheRepository<PersonAccomplishment>, IPersonAccomplishmentRepository
{
    private readonly PersonAccomplishmentRepository _personAccomplishmentRepository;

    public PersonAccomplishmentCacheRepository(DomainContext context, PersonAccomplishmentRepository personAccomplishmentRepository, IMemoryCache memoryCache)
        : base(context, memoryCache)
    {
        _personAccomplishmentRepository = personAccomplishmentRepository;
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
