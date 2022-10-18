using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.SportLeagueLevels;

public record SaveSportLeagueLevel(SaveSportLeagueLevelViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveSportLeagueLevel>
    {
        private readonly IDomainRepository<SportLeagueLevel> _sportLeagueLevelRepository;

        public Handler(IDomainRepository<SportLeagueLevel> sportLeagueLevelRepository)
        {
            _sportLeagueLevelRepository = sportLeagueLevelRepository;
        }

        protected override async Task Handle(SaveSportLeagueLevel request)
        {
            SportLeagueLevel sportLeagueLevel;

            if (request.ViewModel.IsNew)
            {
                sportLeagueLevel = new SportLeagueLevel(request.ViewModel.SportId,
                                                        request.ViewModel.LevelTypeId,
                                                        request.ViewModel.Name,
                                                        request.ViewModel.Abbreviation);

                await _sportLeagueLevelRepository.Add(sportLeagueLevel);

                return;
            }

            sportLeagueLevel = await _sportLeagueLevelRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _sportLeagueLevelRepository.Delete(sportLeagueLevel);

                return;
            }

            sportLeagueLevel.Set(request.ViewModel.SportId,
                                 request.ViewModel.LevelTypeId,
                                 request.ViewModel.Name,
                                 request.ViewModel.Abbreviation);

            await _sportLeagueLevelRepository.Update(sportLeagueLevel);
        }
    }
}
