using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class TeamLeagueRepository : DomainRepository<TeamLeague>, ITeamLeagueRepository
{
    public TeamLeagueRepository(DomainContext context, IMemoryCache memoryCache) : base(context, memoryCache) { }

    private IQueryable<TeamLeague> TeamLeague => Items.Include(teamLeague => teamLeague.Team);

    public override async Task<TeamLeague> Get(int id)
    {
        return await TeamLeague.SingleOrDefaultAsync(teamLeague => teamLeague.Id == id);
    }

    public async Task<IEnumerable<TeamLeague>> GetAll(int? teamId = null)
    {
        return teamId.HasValue
            ? await TeamLeague.Where(teamLeague => teamLeague.TeamId == teamId).ToListAsync()
            : await TeamLeague.ToListAsync();
    }
}
