namespace Memorabilia.Repository.Implementations;

public class AccomplishDetailRepository
    : DomainRepository<Entity.AccomplishmentDetail>, IAccomplishmentDetailRepository
{
    public AccomplishDetailRepository(DomainContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }

    public async Task<Entity.AccomplishmentDetail[]> GetAll(int accomplishmentTypeId)
        => await Items.Where(accomplishmentDetail => accomplishmentDetail.AccomplishmentTypeId == accomplishmentTypeId)
                      .ToArrayAsync();
}
