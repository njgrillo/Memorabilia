namespace Memorabilia.Repository.Implementations;

public class LeaguePresidentRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<LeaguePresident>(context, memoryCache), ILeaguePresidentRepository
{
    private IQueryable<LeaguePresident> President 
        => Items.Include(president => president.Person);

    public override async Task<LeaguePresident> Get(int id)
        => await President.SingleOrDefaultAsync(president => president.Id == id);

    public async Task<LeaguePresident[]> GetAll(int? sportLeagueLevelId = null, 
                                                       int? leagueId = null)
        => await President.Where(president => (sportLeagueLevelId == null || president.SportLeagueLevelId == sportLeagueLevelId)
                                           && (leagueId == null || president.LeagueId == leagueId))
                          .ToArrayAsync();
}
