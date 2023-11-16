namespace Memorabilia.Repository.Implementations;

public class TeamLeagueRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<TeamLeague>(context, memoryCache), ITeamLeagueRepository
{
    private IQueryable<TeamLeague> TeamLeague 
        => Items.Include(teamLeague => teamLeague.Team);

    public override async Task<TeamLeague> Get(int id)
        => await TeamLeague.SingleOrDefaultAsync(teamLeague => teamLeague.Id == id);

    public async Task<TeamLeague[]> GetAll(int? teamId = null)
        => teamId.HasValue
            ? await TeamLeague.Where(teamLeague => teamLeague.TeamId == teamId)
                              .ToArrayAsync()
            : await TeamLeague.ToArrayAsync();
}
