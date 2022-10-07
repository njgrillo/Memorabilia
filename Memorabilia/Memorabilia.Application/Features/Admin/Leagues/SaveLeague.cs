using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Leagues;

public class SaveLeague
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<League> _leagueRepository;

        public Handler(IDomainRepository<League> leagueRepository)
        {
            _leagueRepository = leagueRepository;
        }

        protected override async Task Handle(Command command)
        {
            League league;

            if (command.IsNew)
            {
                league = new League(command.SportLeagueLevelId,
                                    command.Name,
                                    command.Abbreviation);

                await _leagueRepository.Add(league);

                return;
            }

            league = await _leagueRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _leagueRepository.Delete(league);

                return;
            }

            league.Set(command.SportLeagueLevelId,
                       command.Name,
                       command.Abbreviation);

            await _leagueRepository.Update(league);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SaveLeagueViewModel _viewModel;

        public Command(SaveLeagueViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public string Abbreviation => _viewModel.Abbreviation;

        public int Id => _viewModel.Id;

        public bool IsDeleted => _viewModel.IsDeleted;

        public bool IsModified => _viewModel.IsModified;

        public bool IsNew => _viewModel.IsNew;


        public string Name => _viewModel.Name;

        public int SportLeagueLevelId => _viewModel.SportLeagueLevelId;
    }
}
