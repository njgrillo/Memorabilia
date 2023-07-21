namespace Memorabilia.Repository.Implementations;

public class AwardDetailRepository
    : DomainRepository<Entity.AwardDetail>, IAwardDetailRepository
{
    public AwardDetailRepository(DomainContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }

    private IQueryable<Entity.AwardDetail> AwardDetails
        => Items.Include(awardDetail => awardDetail.ExclusionYears);

    public override async Task<Entity.AwardDetail> Get(int awardTypeId)
        => await AwardDetails.SingleOrDefaultAsync(awardDetail => awardDetail.AwardTypeId == awardTypeId);
}
