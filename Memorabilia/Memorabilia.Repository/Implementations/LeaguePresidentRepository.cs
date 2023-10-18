namespace Memorabilia.Repository.Implementations;

public class LeaguePresidentRepository 
    : DomainRepository<LeaguePresident>, ILeaguePresidentRepository
{
    public LeaguePresidentRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

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
