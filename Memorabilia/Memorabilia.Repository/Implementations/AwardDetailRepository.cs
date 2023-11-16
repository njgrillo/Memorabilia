namespace Memorabilia.Repository.Implementations;

public class AwardDetailRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<AwardDetail>(context, memoryCache), IAwardDetailRepository
{
    private IQueryable<AwardDetail> AwardDetails
        => Items.Include(awardDetail => awardDetail.ExclusionYears);

    public override async Task<AwardDetail> Get(int awardTypeId)
        => await AwardDetails.SingleOrDefaultAsync(awardDetail => awardDetail.AwardTypeId == awardTypeId);
}
