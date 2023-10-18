namespace Memorabilia.Repository.Implementations;

public class TeamDivisionRepository 
    : DomainRepository<TeamDivision>, ITeamDivisionRepository
{
    public TeamDivisionRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    private IQueryable<TeamDivision> TeamDivision 
        => Items.Include(teamDivision => teamDivision.Team);

    public override async Task<TeamDivision> Get(int id)
        => await TeamDivision.SingleOrDefaultAsync(teamDivision => teamDivision.Id == id);

    public async Task<TeamDivision[]> GetAll(int? teamId = null)
        => teamId.HasValue
            ? await TeamDivision.Where(teamDivision => teamDivision.TeamId == teamId)
                                .ToArrayAsync()
            : await TeamDivision.ToArrayAsync();
}
