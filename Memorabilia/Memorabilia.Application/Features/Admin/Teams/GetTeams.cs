namespace Memorabilia.Application.Features.Admin.Teams
{
    public class GetTeams
    {
        public class Handler : QueryHandler<Query, TeamsViewModel>
        {
            private readonly ITeamRepository _teamRepository;

            public Handler(ITeamRepository teamRepository)
            {
                _teamRepository = teamRepository;
            }

            protected override async Task<TeamsViewModel> Handle(Query query)
            {
                return new TeamsViewModel(await _teamRepository.GetAll(query.FranchiseId, query.SportLeagueLevelId).ConfigureAwait(false));
            }
        }

        public class Query : IQuery<TeamsViewModel>
        {
            public Query(int? franchiseId = null, int? sportLeagueLevelId = null)
            {
                FranchiseId = franchiseId;
                SportLeagueLevelId = sportLeagueLevelId;
            }

            public int? FranchiseId { get; }

            public int? SportLeagueLevelId { get; }
        }
    }
}
