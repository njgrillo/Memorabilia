namespace Memorabilia.Application.Features.Admin.LeaguePresidents;

public record GetLeaguePresident(int Id) : IQuery<Entity.LeaguePresident>
{
    public class Handler(ILeaguePresidentRepository presidentRepository) 
        : QueryHandler<GetLeaguePresident, Entity.LeaguePresident>
    {
        protected override async Task<Entity.LeaguePresident> Handle(GetLeaguePresident query)
            => await presidentRepository.Get(query.Id);
    }
}
