using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.League
{
    public class GetLeague
    {
        public class Handler : QueryHandler<Query, LeagueViewModel>
        {
            private readonly ILeagueRepository _leagueRepository;

            public Handler(ILeagueRepository leagueRepository)
            {
                _leagueRepository = leagueRepository;
            }

            protected override async Task<LeagueViewModel> Handle(Query query)
            {
                var league = await _leagueRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new LeagueViewModel(league);

                return viewModel;
            }
        }

        public class Query : IQuery<LeagueViewModel>
        {
            public Query(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
    }
}
