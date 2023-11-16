namespace Memorabilia.Application.Features.Admin.Teams;

public record GetTeamLeagues(int TeamId) : IQuery<Entity.TeamLeague[]>
{
    public class Handler(ITeamLeagueRepository teamLeagueRepository) 
        : QueryHandler<GetTeamLeagues, Entity.TeamLeague[]>
    {
        protected override async Task<Entity.TeamLeague[]> Handle(GetTeamLeagues query)
            => (await teamLeagueRepository.GetAll(query.TeamId))
                    .OrderBy(teamLeague => teamLeague.LeagueName)
                    .ThenBy(teamLeague => teamLeague.Team?.Name)
                    .ToArray();
    }
}
