using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Team
{
    public class GetTeam
    {
        public class Handler : QueryHandler<Query, TeamViewModel>
        {
            private readonly ITeamRepository _teamRepository;

            public Handler(ITeamRepository teamRepository)
            {
                _teamRepository = teamRepository;
            }

            protected override async Task<TeamViewModel> Handle(Query query)
            {
                var team = await _teamRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new TeamViewModel(team);

                return viewModel;
            }
        }

        public class Query : IQuery<TeamViewModel>
        {
            public Query(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
    }
}
