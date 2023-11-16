namespace Memorabilia.Application.Features.Admin.LeaguePresidents;

public record GetLeaguePresidents(int? SportLeagueLevelId = null, 
                                  int? LeagueId = null) 
    : IQuery<Entity.LeaguePresident[]>
{
    public class Handler(ILeaguePresidentRepository leaguePresidentRepository) 
        : QueryHandler<GetLeaguePresidents, Entity.LeaguePresident[]>
    {
        protected override async Task<Entity.LeaguePresident[]> Handle(GetLeaguePresidents query)
            => await leaguePresidentRepository.GetAll(query.SportLeagueLevelId, query.LeagueId);
    }
}
