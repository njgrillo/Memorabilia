namespace Memorabilia.Application.Features.Admin.Teams;

public class GetTeamDivisions
{
    public class Handler : QueryHandler<Query, IEnumerable<TeamDivisionViewModel>>
    {
        private readonly ITeamDivisionRepository _teamDivisionRepository;

        public Handler(ITeamDivisionRepository teamDivisionRepository)
        {
            _teamDivisionRepository = teamDivisionRepository;
        }

        protected override async Task<IEnumerable<TeamDivisionViewModel>> Handle(Query query)
        {
            var teamDivisions = (await _teamDivisionRepository.GetAll(query.TeamId))
                                        .OrderBy(teamDivision => teamDivision.DivisionName)
                                        .ThenBy(teamDivision => teamDivision.Team?.Name);

            return teamDivisions.Select(teamDivision => new TeamDivisionViewModel(teamDivision));
        }
    }

    public class Query : IQuery<IEnumerable<TeamDivisionViewModel>>
    {
        public Query(int teamId)
        {
            TeamId = teamId;
        }

        public int TeamId { get; }
    }
}
