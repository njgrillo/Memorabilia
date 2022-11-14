namespace Memorabilia.Application.Features.Admin.LeaguePresidents;

public record GetLeaguePresident(int Id) : IQuery<LeaguePresidentViewModel>
{
    public class Handler : QueryHandler<GetLeaguePresident, LeaguePresidentViewModel>
    {
        private readonly ILeaguePresidentRepository _presidentRepository;

        public Handler(ILeaguePresidentRepository presidentRepository)
        {
            _presidentRepository = presidentRepository;
        }

        protected override async Task<LeaguePresidentViewModel> Handle(GetLeaguePresident query)
        {
            return new LeaguePresidentViewModel(await _presidentRepository.Get(query.Id));
        }
    }
}
