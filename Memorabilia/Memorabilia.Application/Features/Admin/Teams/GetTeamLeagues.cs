namespace Memorabilia.Application.Features.Admin.Teams;

public record GetTeamLeagues(int TeamId) : IQuery<IEnumerable<TeamLeagueViewModel>>
{
    public class Handler : QueryHandler<GetTeamLeagues, IEnumerable<TeamLeagueViewModel>>
    {
        private readonly ITeamLeagueRepository _teamLeagueRepository;

        public Handler(ITeamLeagueRepository teamLeagueRepository)
        {
            _teamLeagueRepository = teamLeagueRepository;
        }

        protected override async Task<IEnumerable<TeamLeagueViewModel>> Handle(GetTeamLeagues query)
        {
            var teamLeagues = (await _teamLeagueRepository.GetAll(query.TeamId))
                                    .OrderBy(teamLeague => teamLeague.LeagueName)
                                    .ThenBy(teamLeague => teamLeague.Team?.Name);

            return teamLeagues.Select(teamLeague => new TeamLeagueViewModel(teamLeague));
        }
    }
}
