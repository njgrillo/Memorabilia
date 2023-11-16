namespace Memorabilia.Repository.Implementations;

public class AccomplishDetailRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<AccomplishmentDetail>(context, memoryCache), IAccomplishmentDetailRepository
{
    public async Task<AccomplishmentDetail[]> GetAll(int accomplishmentTypeId)
        => await Items.Where(accomplishmentDetail => accomplishmentDetail.AccomplishmentTypeId == accomplishmentTypeId)
                      .ToArrayAsync();
}
