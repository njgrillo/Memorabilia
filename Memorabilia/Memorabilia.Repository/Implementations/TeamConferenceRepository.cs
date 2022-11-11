using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class TeamConferenceRepository : DomainRepository<TeamConference>, ITeamConferenceRepository
{
    public TeamConferenceRepository(DomainContext context, IMemoryCache memoryCache) : base(context, memoryCache) { }

    private IQueryable<TeamConference> TeamConference => Items.Include(teamConference => teamConference.Team);


    public override async Task<TeamConference> Get(int id)
    {
        return await TeamConference.SingleOrDefaultAsync(teamConference => teamConference.Id == id);
    }

    public async Task<IEnumerable<TeamConference>> GetAll(int? teamId = null)
    {
        return teamId.HasValue
            ? await TeamConference.Where(teamConference => teamConference.TeamId == teamId).ToListAsync()
            : await TeamConference.ToListAsync();
    }
}
