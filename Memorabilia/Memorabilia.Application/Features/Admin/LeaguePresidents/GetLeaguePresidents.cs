namespace Memorabilia.Application.Features.Admin.LeaguePresidents;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetLeaguePresidents(int? SportLeagueLevelId = null, 
                                  int? LeagueId = null) 
    : IQuery<Entity.LeaguePresident[]>
{
    public class Handler : QueryHandler<GetLeaguePresidents, Entity.LeaguePresident[]>
    {
        private readonly ILeaguePresidentRepository _leaguePresidentRepository;

        public Handler(ILeaguePresidentRepository leaguePresidentRepository)
        {
            _leaguePresidentRepository = leaguePresidentRepository;
        }

        protected override async Task<Entity.LeaguePresident[]> Handle(GetLeaguePresidents query)
            => await _leaguePresidentRepository.GetAll(query.SportLeagueLevelId, query.LeagueId);
    }
}
