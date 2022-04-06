using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Leagues
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
                return new LeaguesViewModel(await _leagueRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<LeaguesViewModel>
        {
            public Query() { }
        }
    }
}
