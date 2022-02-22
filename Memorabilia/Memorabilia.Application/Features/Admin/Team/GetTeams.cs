using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Team
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
                var teams = await _teamRepository.GetAll(query.FranchiseId, query.SportLeagueLevelId).ConfigureAwait(false);

                var viewModel = new TeamsViewModel(teams);

                return viewModel;
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
