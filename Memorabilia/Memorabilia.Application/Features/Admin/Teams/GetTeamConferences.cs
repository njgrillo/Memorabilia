namespace Memorabilia.Application.Features.Admin.Teams;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetTeamConferences(int TeamId) : IQuery<Entity.TeamConference[]>
{
    public class Handler : QueryHandler<GetTeamConferences, Entity.TeamConference[]>
    {
        private readonly ITeamConferenceRepository _teamConferenceRepository;

        public Handler(ITeamConferenceRepository teamConferenceRepository)
        {
            _teamConferenceRepository = teamConferenceRepository;
        }

        protected override async Task<Entity.TeamConference[]> Handle(GetTeamConferences query)
            => (await _teamConferenceRepository.GetAll(query.TeamId))
                    .OrderBy(teamConference => teamConference.ConferenceName)
                    .ThenBy(teamConference => teamConference.Team?.Name)
                    .ToArray();
    }
}
