namespace Memorabilia.Repository.Cache;

public class PersonAccomplishmentCacheRepository(DomainContext context,
                                                 PersonAccomplishmentRepository personAccomplishmentRepository,
                                                 IMemoryCache memoryCache)
    : DomainCacheRepository<PersonAccomplishment>(context, memoryCache), IPersonAccomplishmentRepository
{
    public override async Task Add(PersonAccomplishment item, 
                                   CancellationToken cancellationToken = default)
    {
        RemoveFromCache($"PersonAccomplishment_GetAll_{item.AccomplishmentTypeId}");

        await personAccomplishmentRepository.Add(item, cancellationToken);
    }

    public Task<IEnumerable<PersonAccomplishment>> GetAll(int accomplishmentTypeId)
        => GetAll($"PersonAccomplishment_GetAll_{accomplishmentTypeId}",
                  entry =>
                  {
                      entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
                      return personAccomplishmentRepository.GetAll(accomplishmentTypeId);
                  });
}
