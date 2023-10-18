namespace Memorabilia.Repository.Implementations;

public class AwardDetailRepository
    : DomainRepository<AwardDetail>, IAwardDetailRepository
{
    public AwardDetailRepository(DomainContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }

    private IQueryable<AwardDetail> AwardDetails
        => Items.Include(awardDetail => awardDetail.ExclusionYears);

    public override async Task<AwardDetail> Get(int awardTypeId)
        => await AwardDetails.SingleOrDefaultAsync(awardDetail => awardDetail.AwardTypeId == awardTypeId);
}
