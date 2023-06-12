namespace Memorabilia.Repository.Implementations;

public class TeamConferenceRepository 
    : DomainRepository<Entity.TeamConference>, ITeamConferenceRepository
{
    public TeamConferenceRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    private IQueryable<Entity.TeamConference> TeamConference 
        => Items.Include(teamConference => teamConference.Team);


    public override async Task<Entity.TeamConference> Get(int id)
        => await TeamConference.SingleOrDefaultAsync(teamConference => teamConference.Id == id);

    public async Task<Entity.TeamConference[]> GetAll(int? teamId = null)
        => teamId.HasValue 
            ? await TeamConference.Where(teamConference => teamConference.TeamId == teamId)
                                  .ToArrayAsync() 
            : await TeamConference.ToArrayAsync();
}
