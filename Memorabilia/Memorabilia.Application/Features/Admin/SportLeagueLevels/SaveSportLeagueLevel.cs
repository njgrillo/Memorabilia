namespace Memorabilia.Application.Features.Admin.SportLeagueLevels;

public record SaveSportLeagueLevel(SportLeagueLevelEditModel SportLeagueLevel) : ICommand
{
    public class Handler : CommandHandler<SaveSportLeagueLevel>
    {
        private readonly IDomainRepository<Entity.SportLeagueLevel> _sportLeagueLevelRepository;

        public Handler(IDomainRepository<Entity.SportLeagueLevel> sportLeagueLevelRepository)
        {
            _sportLeagueLevelRepository = sportLeagueLevelRepository;
        }

        protected override async Task Handle(SaveSportLeagueLevel request)
        {
            Entity.SportLeagueLevel sportLeagueLevel;

            if (request.SportLeagueLevel.IsNew)
            {
                sportLeagueLevel = new Entity.SportLeagueLevel(request.SportLeagueLevel.SportId,
                                                               request.SportLeagueLevel.LevelTypeId,
                                                               request.SportLeagueLevel.Name,
                                                               request.SportLeagueLevel.Abbreviation);

                await _sportLeagueLevelRepository.Add(sportLeagueLevel);

                return;
            }

            sportLeagueLevel = await _sportLeagueLevelRepository.Get(request.SportLeagueLevel.Id);

            if (request.SportLeagueLevel.IsDeleted)
            {
                await _sportLeagueLevelRepository.Delete(sportLeagueLevel);

                return;
            }

            sportLeagueLevel.Set(request.SportLeagueLevel.SportId,
                                 request.SportLeagueLevel.LevelTypeId,
                                 request.SportLeagueLevel.Name,
                                 request.SportLeagueLevel.Abbreviation);

            await _sportLeagueLevelRepository.Update(sportLeagueLevel);
        }
    }
}
