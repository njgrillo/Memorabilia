namespace Memorabilia.Repository.Implementations;

public class AccomplishDetailRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<AccomplishmentDetail>(context, memoryCache), IAccomplishmentDetailRepository
{
    public override async Task<AccomplishmentDetail> Get(int id)
        => await Items.SingleOrDefaultAsync(accomplishmentDetail => accomplishmentDetail.AccomplishmentTypeId == id);

    public async Task<AccomplishmentDetail[]> GetAll(int accomplishmentTypeId)
        => await Items.Where(accomplishmentDetail => accomplishmentDetail.AccomplishmentTypeId == accomplishmentTypeId)
                      .ToArrayAsync();
}
