using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.SportLeagueLevels;

public class SaveSportLeagueLevel
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<SportLeagueLevel> _sportLeagueLevelRepository;

        public Handler(IDomainRepository<SportLeagueLevel> sportLeagueLevelRepository)
        {
            _sportLeagueLevelRepository = sportLeagueLevelRepository;
        }

        protected override async Task Handle(Command command)
        {
            Domain.Entities.SportLeagueLevel sportLeagueLevel;

            if (command.IsNew)
            {
                sportLeagueLevel = new Domain.Entities.SportLeagueLevel(command.SportId,
                                                                        command.LevelTypeId,
                                                                        command.Name,
                                                                        command.Abbreviation);

                await _sportLeagueLevelRepository.Add(sportLeagueLevel);

                return;
            }

            sportLeagueLevel = await _sportLeagueLevelRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _sportLeagueLevelRepository.Delete(sportLeagueLevel);

                return;
            }

            sportLeagueLevel.Set(command.SportId,
                                 command.LevelTypeId,
                                 command.Name,
                                 command.Abbreviation);

            await _sportLeagueLevelRepository.Update(sportLeagueLevel);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SaveSportLeagueLevelViewModel _viewModel;

        public Command(SaveSportLeagueLevelViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public string Abbreviation => _viewModel.Abbreviation;

        public int Id => _viewModel.Id;

        public bool IsDeleted => _viewModel.IsDeleted;

        public bool IsModified => _viewModel.IsModified;

        public bool IsNew => _viewModel.IsNew;

        public int LevelTypeId => _viewModel.LevelTypeId;

        public string Name => _viewModel.Name;

        public int SportId => _viewModel.SportId;
    }
}
