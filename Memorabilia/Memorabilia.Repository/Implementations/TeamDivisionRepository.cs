using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class TeamDivisionRepository : DomainRepository<TeamDivision>, ITeamDivisionRepository
{
    public TeamDivisionRepository(DomainContext context, IMemoryCache memoryCache) : base(context, memoryCache) { }

    private IQueryable<TeamDivision> TeamDivision => Items.Include(teamDivision => teamDivision.Team);

    public override async Task<TeamDivision> Get(int id)
    {
        return await TeamDivision.SingleOrDefaultAsync(teamDivision => teamDivision.Id == id);
    }

    public async Task<IEnumerable<TeamDivision>> GetAll(int? teamId = null)
    {
        return teamId.HasValue
            ? await TeamDivision.Where(teamDivision => teamDivision.TeamId == teamId).ToListAsync()
            : await TeamDivision.ToListAsync();
    }
}
