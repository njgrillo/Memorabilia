namespace Memorabilia.Application.Features.Admin.LeaguePresidents;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetLeaguePresident(int Id) : IQuery<Entity.LeaguePresident>
{
    public class Handler : QueryHandler<GetLeaguePresident, Entity.LeaguePresident>
    {
        private readonly ILeaguePresidentRepository _presidentRepository;

        public Handler(ILeaguePresidentRepository presidentRepository)
        {
            _presidentRepository = presidentRepository;
        }

        protected override async Task<Entity.LeaguePresident> Handle(GetLeaguePresident query)
            => await _presidentRepository.Get(query.Id);
    }
}
