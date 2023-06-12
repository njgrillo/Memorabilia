namespace Memorabilia.Repository.Implementations;

public class TeamDivisionRepository 
    : DomainRepository<Entity.TeamDivision>, ITeamDivisionRepository
{
    public TeamDivisionRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    private IQueryable<Entity.TeamDivision> TeamDivision 
        => Items.Include(teamDivision => teamDivision.Team);

    public override async Task<Entity.TeamDivision> Get(int id)
        => await TeamDivision.SingleOrDefaultAsync(teamDivision => teamDivision.Id == id);

    public async Task<Entity.TeamDivision[]> GetAll(int? teamId = null)
        => teamId.HasValue
            ? await TeamDivision.Where(teamDivision => teamDivision.TeamId == teamId)
                                .ToArrayAsync()
            : await TeamDivision.ToArrayAsync();
}
