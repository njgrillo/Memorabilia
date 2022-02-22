using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.League
{
    public class GetLeagues
    {
        public class Handler : QueryHandler<Query, LeaguesViewModel>
        {
            private readonly ILeagueRepository _leagueRepository;

            public Handler(ILeagueRepository leagueRepository)
            {
                _leagueRepository = leagueRepository;
            }

            protected override async Task<LeaguesViewModel> Handle(Query query)
            {
                var leagues = await _leagueRepository.GetAll().ConfigureAwait(false);

                var viewModel = new LeaguesViewModel(leagues);

                return viewModel;
            }
        }

        public class Query : IQuery<LeaguesViewModel>
        {
            public Query() { }
        }
    }
}
