namespace Memorabilia.Application.Features.Admin.Teams;

public class GetTeamLeagues
{
    public class Handler : QueryHandler<Query, IEnumerable<TeamLeagueViewModel>>
    {
        private readonly ITeamLeagueRepository _teamLeagueRepository;

        public Handler(ITeamLeagueRepository teamLeagueRepository)
        {
            _teamLeagueRepository = teamLeagueRepository;
        }

        protected override async Task<IEnumerable<TeamLeagueViewModel>> Handle(Query query)
        {
            var teamLeagues = (await _teamLeagueRepository.GetAll(query.TeamId))
                                    .OrderBy(teamLeague => teamLeague.LeagueName)
                                    .ThenBy(teamLeague => teamLeague.Team?.Name);

            return teamLeagues.Select(teamLeague => new TeamLeagueViewModel(teamLeague));
        }
    }

    public class Query : IQuery<IEnumerable<TeamLeagueViewModel>>
    {
        public Query(int teamId)
        {
            TeamId = teamId;
        }

        public int TeamId { get; }
    }
}
