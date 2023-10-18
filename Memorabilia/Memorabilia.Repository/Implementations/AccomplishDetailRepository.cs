namespace Memorabilia.Repository.Implementations;

public class AccomplishDetailRepository
    : DomainRepository<AccomplishmentDetail>, IAccomplishmentDetailRepository
{
    public AccomplishDetailRepository(DomainContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }

    public async Task<AccomplishmentDetail[]> GetAll(int accomplishmentTypeId)
        => await Items.Where(accomplishmentDetail => accomplishmentDetail.AccomplishmentTypeId == accomplishmentTypeId)
                      .ToArrayAsync();
}
