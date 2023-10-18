namespace Memorabilia.Repository.Implementations;

public class AllStarDetailRepository
    : DomainRepository<AllStarDetail>, IAllStarDetailRepository
{
    public AllStarDetailRepository(DomainContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }

    private IQueryable<AllStarDetail> AllStarDetails
        => Items.Include(allStarDetail => allStarDetail.SportLeagueLevel);

    public async Task<AllStarDetail[]> GetAll(int sportLeagueLevelId)
        => await AllStarDetails.Where(allStarDetail => allStarDetail.SportLeagueLevelId == sportLeagueLevelId)
                               .ToArrayAsync();
}
