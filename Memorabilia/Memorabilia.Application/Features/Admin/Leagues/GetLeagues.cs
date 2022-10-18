using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Leagues;

public record GetLeagues() : IQuery<LeaguesViewModel>
{
    public class Handler : QueryHandler<GetLeagues, LeaguesViewModel>
    {
        private readonly IDomainRepository<League> _leagueRepository;

        public Handler(IDomainRepository<League> leagueRepository)
        {
            _leagueRepository = leagueRepository;
        }

        protected override async Task<LeaguesViewModel> Handle(GetLeagues query)
        {
            return new LeaguesViewModel(await _leagueRepository.GetAll());
        }
    }
}
