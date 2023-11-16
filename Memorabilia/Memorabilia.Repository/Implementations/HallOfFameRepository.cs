namespace Memorabilia.Repository.Implementations;

public class HallOfFameRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<HallOfFame>(context, memoryCache), IHallOfFameRepository
{
    private IQueryable<HallOfFame> HallOfFames 
        => Items.Include(hallOfFame => hallOfFame.Person);

    public async Task<IEnumerable<HallOfFame>> GetAll(int? sportLeagueLevelId = null, 
                                                             int? inductionYear = null)
        => await HallOfFames.Where(hof => (sportLeagueLevelId == null || hof.SportLeagueLevelId == sportLeagueLevelId)
                                       && (inductionYear == null || hof.InductionYear == inductionYear))
                            .AsNoTracking()
                            .ToListAsync();
}
