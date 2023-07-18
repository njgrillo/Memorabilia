namespace Memorabilia.Repository.Implementations;

public class AwardDetailRepository
    : DomainRepository<Entity.AwardDetail>, IAwardDetailRepository
{
    public AwardDetailRepository(DomainContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }

    private IQueryable<Entity.AwardDetail> AwardDetails
        => Items.Include(awardDetail => awardDetail.ExclusionYears);

    public override async Task<Entity.AwardDetail> Get(int awardTypeId)
        => await Items.SingleOrDefaultAsync(awardDetail => awardDetail.AwardTypeId == awardTypeId);

    //public async Task<object[]> GetAllManagement()
    //{
    //    var query =
    //        from awardType in Context.AwardType
    //        join awardDetail in Context.AwardDetail on awardType equals awardDetail.AwardTypeId into at
    //        from at in at.DefaultIfEmpty()
    //        select new Entity.Memorabilia(memorabilia);

    //    return await query.ToArrayAsync();
    //}
}
