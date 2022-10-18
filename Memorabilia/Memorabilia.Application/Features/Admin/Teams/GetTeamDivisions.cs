namespace Memorabilia.Application.Features.Admin.Teams;

public record GetTeamDivisions(int TeamId) : IQuery<IEnumerable<TeamDivisionViewModel>>
{
    public class Handler : QueryHandler<GetTeamDivisions, IEnumerable<TeamDivisionViewModel>>
    {
        private readonly ITeamDivisionRepository _teamDivisionRepository;

        public Handler(ITeamDivisionRepository teamDivisionRepository)
        {
            _teamDivisionRepository = teamDivisionRepository;
        }

        protected override async Task<IEnumerable<TeamDivisionViewModel>> Handle(GetTeamDivisions query)
        {
            var teamDivisions = (await _teamDivisionRepository.GetAll(query.TeamId))
                                        .OrderBy(teamDivision => teamDivision.DivisionName)
                                        .ThenBy(teamDivision => teamDivision.Team?.Name);

            return teamDivisions.Select(teamDivision => new TeamDivisionViewModel(teamDivision));
        }
    }
}
