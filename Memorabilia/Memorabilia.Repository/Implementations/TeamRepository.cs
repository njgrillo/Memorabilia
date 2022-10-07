using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class TeamRepository : DomainRepository<Team>, ITeamRepository
{
    public TeamRepository(DomainContext context) : base(context) { }

    private IQueryable<Team> Team => Items.Include(team => team.Conferences)
                                          .Include(team => team.Divisions)
                                          .Include(team => team.Franchise)
                                          .Include(team => team.Leagues);

    public override async Task<Team> Get(int id)
    {
        return await Team.SingleOrDefaultAsync(team => team.Id == id);
    }

    public async Task<IEnumerable<Team>> GetAll(int? franchiseId = null, int? sportLeagueLevelId = null)
    {
        if (franchiseId.HasValue)
        {
            return (await Team.Where(team => team.FranchiseId == franchiseId)
                              .ToListAsync()).OrderBy(team => team.Name);
        }

        if (sportLeagueLevelId.HasValue)
        {
            return (await Team.Where(team => team.Franchise.SportLeagueLevelId == sportLeagueLevelId)
                              .ToListAsync()).OrderBy(team => team.Franchise.SportLeagueLevelName)
                                             .ThenBy(team => team.Name);
        }

        return (await Team.ToListAsync()).OrderBy(team => team.Franchise.SportLeagueLevelName)
                                         .ThenBy(team => team.Name);
    }
}
