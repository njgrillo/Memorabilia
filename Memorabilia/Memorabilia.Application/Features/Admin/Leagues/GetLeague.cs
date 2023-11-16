namespace Memorabilia.Application.Features.Admin.Leagues;

public record GetLeague(int Id) : IQuery<Entity.League>
{
    public class Handler(IDomainRepository<Entity.League> leagueRepository) 
        : QueryHandler<GetLeague, Entity.League>
    {
        protected override async Task<Entity.League> Handle(GetLeague query)
            => await leagueRepository.Get(query.Id);
    }
}
