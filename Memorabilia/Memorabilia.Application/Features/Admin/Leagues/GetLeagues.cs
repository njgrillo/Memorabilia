namespace Memorabilia.Application.Features.Admin.Leagues;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetLeagues() : IQuery<Entity.League[]>
{
    public class Handler : QueryHandler<GetLeagues, Entity.League[]>
    {
        private readonly IDomainRepository<Entity.League> _leagueRepository;

        public Handler(IDomainRepository<Entity.League> leagueRepository)
        {
            _leagueRepository = leagueRepository;
        }

        protected override async Task<Entity.League[]> Handle(GetLeagues query)
            => await _leagueRepository.GetAll();
    }
}
