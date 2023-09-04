namespace Memorabilia.Application.Features.Admin.Leagues;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetLeague(int Id) : IQuery<Entity.League>
{
    public class Handler : QueryHandler<GetLeague, Entity.League>
    {
        private readonly IDomainRepository<Entity.League> _leagueRepository;

        public Handler(IDomainRepository<Entity.League> leagueRepository)
        {
            _leagueRepository = leagueRepository;
        }

        protected override async Task<Entity.League> Handle(GetLeague query)
            => await _leagueRepository.Get(query.Id);
    }
}
