namespace Memorabilia.Repository.Implementations;

public class AllStarDetailRepository
    : DomainRepository<Entity.AllStarDetail>, IAllStarDetailRepository
{
    public AllStarDetailRepository(DomainContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }

    private IQueryable<Entity.AllStarDetail> AllStarDetails
        => Items.Include(allStarDetail => allStarDetail.SportLeagueLevel);

    public async Task<Entity.AllStarDetail[]> GetAll(int sportLeagueLevelId)
        => await AllStarDetails.Where(allStarDetail => allStarDetail.SportLeagueLevelId == sportLeagueLevelId)
                               .ToArrayAsync();
}
