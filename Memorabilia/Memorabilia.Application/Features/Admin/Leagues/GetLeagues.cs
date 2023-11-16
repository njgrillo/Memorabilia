namespace Memorabilia.Application.Features.Admin.Leagues;

public record GetLeagues() : IQuery<Entity.League[]>
{
    public class Handler(IDomainRepository<Entity.League> leagueRepository) 
        : QueryHandler<GetLeagues, Entity.League[]>
    {
        protected override async Task<Entity.League[]> Handle(GetLeagues query)
            => await leagueRepository.GetAll();
    }
}
