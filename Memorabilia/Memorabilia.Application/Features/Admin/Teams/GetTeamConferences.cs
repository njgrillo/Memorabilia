namespace Memorabilia.Application.Features.Admin.Teams
{
    public class GetTeamConferences
    {
        public class Handler : QueryHandler<Query, IEnumerable<TeamConferenceViewModel>>
        {
            private readonly ITeamConferenceRepository _teamConferenceRepository;

            public Handler(ITeamConferenceRepository teamConferenceRepository)
            {
                _teamConferenceRepository = teamConferenceRepository;
            }

            protected override async Task<IEnumerable<TeamConferenceViewModel>> Handle(Query query)
            {
                var teamConferences = await _teamConferenceRepository.GetAll(query.TeamId).ConfigureAwait(false);

                return teamConferences.Select(teamConference => new TeamConferenceViewModel(teamConference));
            }
        }

        public class Query : IQuery<IEnumerable<TeamConferenceViewModel>>
        {
            public Query(int teamId)
            {
                TeamId = teamId;
            }

            public int TeamId { get; }
        }
    }
}
