namespace Memorabilia.Repository.Implementations;

public class AllStarRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<AllStar>(context, memoryCache), IAllStarRepository
{
    private IQueryable<AllStar> AllStars 
        => Items.Include(allStar => allStar.Person);

    public async Task<IEnumerable<AllStar>> GetAll(int year, Constant.Sport sport = null)
        => (await AllStars.Where(allStar => allStar.Year == year && (sport == null || allStar.SportId == sport.Id))
                          .AsNoTracking()
                          .ToArrayAsync())
                  .OrderByDescending(allStar => allStar.Person.DisplayName);

    public async Task<IEnumerable<AllStar>> GetAll(int sportId, int? year = null)
        => (await AllStars.Where(allStar => allStar.SportId == sportId && (year == null || allStar.Year == year))
                          .AsNoTracking()
                          .ToArrayAsync())
                  .OrderBy(allStar => allStar.SportId);
}
