namespace Memorabilia.Repository.Implementations;

public class TeamConferenceRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<TeamConference>(context, memoryCache), ITeamConferenceRepository
{
    private IQueryable<TeamConference> TeamConference 
        => Items.Include(teamConference => teamConference.Team);


    public override async Task<TeamConference> Get(int id)
        => await TeamConference.SingleOrDefaultAsync(teamConference => teamConference.Id == id);

    public async Task<TeamConference[]> GetAll(int? teamId = null)
        => teamId.HasValue 
            ? await TeamConference.Where(teamConference => teamConference.TeamId == teamId)
                                  .ToArrayAsync() 
            : await TeamConference.ToArrayAsync();
}
