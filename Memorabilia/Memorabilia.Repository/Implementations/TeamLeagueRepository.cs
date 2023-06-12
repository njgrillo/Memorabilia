namespace Memorabilia.Repository.Implementations;

public class TeamLeagueRepository 
    : DomainRepository<Entity.TeamLeague>, ITeamLeagueRepository
{
    public TeamLeagueRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    private IQueryable<Entity.TeamLeague> TeamLeague 
        => Items.Include(teamLeague => teamLeague.Team);

    public override async Task<Entity.TeamLeague> Get(int id)
        => await TeamLeague.SingleOrDefaultAsync(teamLeague => teamLeague.Id == id);

    public async Task<Entity.TeamLeague[]> GetAll(int? teamId = null)
        => teamId.HasValue
            ? await TeamLeague.Where(teamLeague => teamLeague.TeamId == teamId)
                              .ToArrayAsync()
            : await TeamLeague.ToArrayAsync();
}
