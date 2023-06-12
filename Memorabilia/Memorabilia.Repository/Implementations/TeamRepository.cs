namespace Memorabilia.Repository.Implementations;

public class TeamRepository 
    : DomainRepository<Entity.Team>, ITeamRepository
{
    public TeamRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    private IQueryable<Entity.Team> Team 
        => Items.Include(team => team.Conferences)
                .Include(team => team.Divisions)
                .Include(team => team.Franchise)
                .Include(team => team.Leagues);

    public override async Task<Entity.Team> Get(int id)
        => await Team.SingleOrDefaultAsync(team => team.Id == id);

    public async Task<Entity.Team[]> GetAll(int? franchiseId = null, 
                                            int? sportLeagueLevelId = null, 
                                            int? sportId = null)
        => (await Team.Where(team => (!franchiseId.HasValue || team.FranchiseId == franchiseId)
                                          && (!sportLeagueLevelId.HasValue || team.Franchise.SportLeagueLevelId == sportLeagueLevelId)
                                          && (!sportId.HasValue || team.Franchise.SportLeagueLevel.SportId == sportId))
                      .ToArrayAsync())
                .OrderBy(team => team.Name)
                .ToArray();

    public async Task<Entity.Team[]> GetAllCurrentTeams(int? sportId = null)
        => await Team.Where(team => (!sportId.HasValue || team.Franchise.SportLeagueLevel.SportId == sportId)
                                     && team.EndYear == null)
                     .OrderBy(team => team.Franchise.Location)
                     .ThenBy(team => team.Franchise.Name)
                     .ToArrayAsync();
}
