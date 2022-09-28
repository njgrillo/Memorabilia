namespace Memorabilia.Application.Features.Admin.Leagues
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
                return new LeagueViewModel(await _leagueRepository.Get(query.Id).ConfigureAwait(false));
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
