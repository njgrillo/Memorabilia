namespace Memorabilia.Application.Features.Admin.SportLeagueLevels;

public record GetSportLeagueLevels() : IQuery<Entity.SportLeagueLevel[]>
{
    public class Handler(IDomainRepository<Entity.SportLeagueLevel> sportLeagueLevelRepository) 
        : QueryHandler<GetSportLeagueLevels, Entity.SportLeagueLevel[]>
    {
        protected override async Task<Entity.SportLeagueLevel[]> Handle(GetSportLeagueLevels query)
            => (await sportLeagueLevelRepository.GetAll())
                    .OrderBy(sportLeagueLevel => sportLeagueLevel.SportName)
                    .ThenBy(sportLeagueLevel => sportLeagueLevel.Name)
                    .ToArray();
    }
}
