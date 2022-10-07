using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Leagues;

public class GetLeagues
{
    public class Handler : QueryHandler<Query, LeaguesViewModel>
    {
        private readonly IDomainRepository<League> _leagueRepository;

        public Handler(IDomainRepository<League> leagueRepository)
        {
            _leagueRepository = leagueRepository;
        }

        protected override async Task<LeaguesViewModel> Handle(Query query)
        {
            return new LeaguesViewModel(await _leagueRepository.GetAll());
        }
    }

    public class Query : IQuery<LeaguesViewModel>
    {
        public Query() { }
    }
}
