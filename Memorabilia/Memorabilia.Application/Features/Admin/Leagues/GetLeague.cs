using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Leagues;

public record GetLeague(int Id) : IQuery<LeagueViewModel>
{
    public class Handler : QueryHandler<GetLeague, LeagueViewModel>
    {
        private readonly IDomainRepository<League> _leagueRepository;

        public Handler(IDomainRepository<League> leagueRepository)
        {
            _leagueRepository = leagueRepository;
        }

        protected override async Task<LeagueViewModel> Handle(GetLeague query)
        {
            return new LeagueViewModel(await _leagueRepository.Get(query.Id));
        }
    }
}
