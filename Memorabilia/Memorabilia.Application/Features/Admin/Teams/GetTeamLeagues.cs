namespace Memorabilia.Application.Features.Admin.Teams;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetTeamLeagues(int TeamId) : IQuery<Entity.TeamLeague[]>
{
    public class Handler : QueryHandler<GetTeamLeagues, Entity.TeamLeague[]>
    {
        private readonly ITeamLeagueRepository _teamLeagueRepository;

        public Handler(ITeamLeagueRepository teamLeagueRepository)
        {
            _teamLeagueRepository = teamLeagueRepository;
        }

        protected override async Task<Entity.TeamLeague[]> Handle(GetTeamLeagues query)
            => (await _teamLeagueRepository.GetAll(query.TeamId))
                    .OrderBy(teamLeague => teamLeague.LeagueName)
                    .ThenBy(teamLeague => teamLeague.Team?.Name)
                    .ToArray();
    }
}
