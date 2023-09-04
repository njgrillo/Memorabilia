namespace Memorabilia.Application.Features.Admin.SportLeagueLevels;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetSportLeagueLevels() : IQuery<Entity.SportLeagueLevel[]>
{
    public class Handler : QueryHandler<GetSportLeagueLevels, Entity.SportLeagueLevel[]>
    {
        private readonly IDomainRepository<Entity.SportLeagueLevel> _sportLeagueLevelRepository;

        public Handler(IDomainRepository<Entity.SportLeagueLevel> sportLeagueLevelRepository)
        {
            _sportLeagueLevelRepository = sportLeagueLevelRepository;
        }

        protected override async Task<Entity.SportLeagueLevel[]> Handle(GetSportLeagueLevels query)
            => (await _sportLeagueLevelRepository.GetAll())
                    .OrderBy(sportLeagueLevel => sportLeagueLevel.SportName)
                    .ThenBy(sportLeagueLevel => sportLeagueLevel.Name)
                    .ToArray();
    }
}
