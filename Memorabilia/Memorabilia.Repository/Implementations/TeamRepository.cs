using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class TeamRepository : DomainRepository<Team>, ITeamRepository
{
    public TeamRepository(DomainContext context, IMemoryCache memoryCache) : base(context, memoryCache) { }

    private IQueryable<Team> Team => Items.Include(team => team.Conferences)
                                          .Include(team => team.Divisions)
                                          .Include(team => team.Franchise)
                                          .Include(team => team.Leagues);

    public override async Task<Team> Get(int id)
    {
        return await Team.SingleOrDefaultAsync(team => team.Id == id);
    }

    public async Task<IEnumerable<Team>> GetAll(int? franchiseId = null, int? sportLeagueLevelId = null, int? sportId = null)
    {
        return (await Team.Where(team => (!franchiseId.HasValue || team.FranchiseId == franchiseId)
                                          && (!sportLeagueLevelId.HasValue || team.Franchise.SportLeagueLevelId == sportLeagueLevelId)
                                          && (!sportId.HasValue || team.Franchise.SportLeagueLevel.SportId == sportId))
                          .ToListAsync())
               .OrderBy(team => team.Name);
    }

    public async Task<Team[]> GetAllCurrentTeams(int? sportId = null)
    {
        return await Team.Where(team => (!sportId.HasValue || team.Franchise.SportLeagueLevel.SportId == sportId)
                                                 && team.EndYear == null)
                                     .OrderBy(team => team.Franchise.Location)
                                     .ThenBy(team => team.Franchise.Name)
                                     .ToArrayAsync();
    }
}
