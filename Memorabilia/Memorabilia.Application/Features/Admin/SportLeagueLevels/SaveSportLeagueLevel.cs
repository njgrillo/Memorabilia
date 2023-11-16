namespace Memorabilia.Application.Features.Admin.SportLeagueLevels;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveSportLeagueLevel(SportLeagueLevelEditModel SportLeagueLevel) : ICommand
{
    public class Handler(IDomainRepository<Entity.SportLeagueLevel> sportLeagueLevelRepository) 
        : CommandHandler<SaveSportLeagueLevel>
    {
        protected override async Task Handle(SaveSportLeagueLevel request)
        {
            Entity.SportLeagueLevel sportLeagueLevel;

            if (request.SportLeagueLevel.IsNew)
            {
                sportLeagueLevel = new Entity.SportLeagueLevel(request.SportLeagueLevel.SportId,
                                                               request.SportLeagueLevel.LevelTypeId,
                                                               request.SportLeagueLevel.Name,
                                                               request.SportLeagueLevel.Abbreviation);

                await sportLeagueLevelRepository.Add(sportLeagueLevel);

                return;
            }

            sportLeagueLevel = await sportLeagueLevelRepository.Get(request.SportLeagueLevel.Id);

            if (request.SportLeagueLevel.IsDeleted)
            {
                await sportLeagueLevelRepository.Delete(sportLeagueLevel);

                return;
            }

            sportLeagueLevel.Set(request.SportLeagueLevel.SportId,
                                 request.SportLeagueLevel.LevelTypeId,
                                 request.SportLeagueLevel.Name,
                                 request.SportLeagueLevel.Abbreviation);

            await sportLeagueLevelRepository.Update(sportLeagueLevel);
        }
    }
}
