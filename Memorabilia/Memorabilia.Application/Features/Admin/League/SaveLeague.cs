using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.League
{
    public class SaveLeague
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly ILeagueRepository _leagueRepository;

            public Handler(ILeagueRepository leagueRepository)
            {
                _leagueRepository = leagueRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.League league;

                if (command.IsNew)
                {
                    league = new Domain.Entities.League(command.SportLeagueLevelId,
                                                        command.Name,
                                                        command.Abbreviation);

                    await _leagueRepository.Add(league).ConfigureAwait(false);

                    return;
                }

                league = await _leagueRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _leagueRepository.Delete(league).ConfigureAwait(false);

                    return;
                }

                league.Set(command.SportLeagueLevelId,
                           command.Name,
                           command.Abbreviation);

                await _leagueRepository.Update(league).ConfigureAwait(false);
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
}
