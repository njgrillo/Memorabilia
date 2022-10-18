namespace Memorabilia.Application.Features.Admin.Teams;

public record GetTeamConferences(int TeamId) : IQuery<IEnumerable<TeamConferenceViewModel>>
{
    public class Handler : QueryHandler<GetTeamConferences, IEnumerable<TeamConferenceViewModel>>
    {
        private readonly ITeamConferenceRepository _teamConferenceRepository;

        public Handler(ITeamConferenceRepository teamConferenceRepository)
        {
            _teamConferenceRepository = teamConferenceRepository;
        }

        protected override async Task<IEnumerable<TeamConferenceViewModel>> Handle(GetTeamConferences query)
        {
            var teamConferences = (await _teamConferenceRepository.GetAll(query.TeamId))
                                            .OrderBy(teamConference => teamConference.ConferenceName)
                                            .ThenBy(teamConference => teamConference.Team?.Name);

            return teamConferences.Select(teamConference => new TeamConferenceViewModel(teamConference));
        }
    }
}
