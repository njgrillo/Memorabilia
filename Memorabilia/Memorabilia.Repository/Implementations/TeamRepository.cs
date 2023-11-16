namespace Memorabilia.Repository.Implementations;

public class TeamRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<Team>(context, memoryCache), ITeamRepository
{
    private IQueryable<Team> Team 
        => Items.Include(team => team.Conferences)
                .Include(team => team.Divisions)
                .Include(team => team.Franchise)
                .Include(team => team.Leagues);

    public override async Task<Team> Get(int id)
        => await Team.SingleOrDefaultAsync(team => team.Id == id);

    public async Task<Team[]> GetAll(int? franchiseId = null, 
                                            int? sportLeagueLevelId = null, 
                                            int? sportId = null)
        => (await Team.Where(team => (!franchiseId.HasValue || team.FranchiseId == franchiseId)
                                  && (!sportLeagueLevelId.HasValue || team.Franchise.SportLeagueLevelId == sportLeagueLevelId)
                                  && (!sportId.HasValue || team.Franchise.SportLeagueLevel.SportId == sportId))
                      .ToArrayAsync())
                .OrderBy(team => team.Name)
                .ToArray();

    public async Task<Team[]> GetAllCurrentTeams(int? sportId = null)
        => await Team.Where(team => (!sportId.HasValue || team.Franchise.SportLeagueLevel.SportId == sportId)
                                 && team.EndYear == null)
                     .OrderBy(team => team.Franchise.Location)
                     .ThenBy(team => team.Franchise.Name)
                     .ToArrayAsync();
}
