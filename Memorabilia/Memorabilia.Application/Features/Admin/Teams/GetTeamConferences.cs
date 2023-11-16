namespace Memorabilia.Application.Features.Admin.Teams;

public record GetTeamConferences(int TeamId) : IQuery<Entity.TeamConference[]>
{
    public class Handler(ITeamConferenceRepository teamConferenceRepository) 
        : QueryHandler<GetTeamConferences, Entity.TeamConference[]>
    {
        protected override async Task<Entity.TeamConference[]> Handle(GetTeamConferences query)
            => (await teamConferenceRepository.GetAll(query.TeamId))
                    .OrderBy(teamConference => teamConference.ConferenceName)
                    .ThenBy(teamConference => teamConference.Team?.Name)
                    .ToArray();
    }
}
