namespace Memorabilia.Application.Features.Admin.LeaguePresidents;

public record GetLeaguePresidents(int? SportLeagueLevelId = null, int? LeagueId = null) : IQuery<LeaguePresidentsViewModel>
{
    public class Handler : QueryHandler<GetLeaguePresidents, LeaguePresidentsViewModel>
    {
        private readonly ILeaguePresidentRepository _leaguePresidentRepository;

        public Handler(ILeaguePresidentRepository leaguePresidentRepository)
        {
            _leaguePresidentRepository = leaguePresidentRepository;
        }

        protected override async Task<LeaguePresidentsViewModel> Handle(GetLeaguePresidents query)
        {
            return new LeaguePresidentsViewModel(await _leaguePresidentRepository.GetAll(query.SportLeagueLevelId, query.LeagueId));
        }
    }
}
