namespace Memorabilia.Application.Features.Admin.SportLeagueLevels;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetSportLeagueLevel(int Id) : IQuery<Entity.SportLeagueLevel>
{
    public class Handler : QueryHandler<GetSportLeagueLevel, Entity.SportLeagueLevel>
    {
        private readonly IDomainRepository<Entity.SportLeagueLevel> _sportLeagueLevelRepository;

        public Handler(IDomainRepository<Entity.SportLeagueLevel> sportLeagueLevelRepository)
        {
            _sportLeagueLevelRepository = sportLeagueLevelRepository;
        }

        protected override async Task<Entity.SportLeagueLevel> Handle(GetSportLeagueLevel query)
            => await _sportLeagueLevelRepository.Get(query.Id);
    }
}
