namespace Memorabilia.Repository.Implementations;

public class AllStarDetailRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<AllStarDetail>(context, memoryCache), IAllStarDetailRepository
{
    private IQueryable<AllStarDetail> AllStarDetails
        => Items.Include(allStarDetail => allStarDetail.SportLeagueLevel);

    public async Task<AllStarDetail[]> GetAll(int sportLeagueLevelId)
        => await AllStarDetails.Where(allStarDetail => allStarDetail.SportLeagueLevelId == sportLeagueLevelId)
                               .ToArrayAsync();
}
