using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Divisions
{
    public class SaveDivision
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IDivisionRepository _divisionRepository;

            public Handler(IDivisionRepository divisionRepository)
            {
                _divisionRepository = divisionRepository;
            }

            protected override async Task Handle(Command command)
            {
                Division division;

                if (command.IsNew)
                {
                    division = new Division(command.ConferenceId,
                                            command.LeagueId,
                                            command.Name,
                                            command.Abbreviation);

                    await _divisionRepository.Add(division).ConfigureAwait(false);

                    return;
                }

                division = await _divisionRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _divisionRepository.Delete(division).ConfigureAwait(false);

                    return;
                }

                division.Set(command.ConferenceId,
                             command.LeagueId,
                             command.Name,
                             command.Abbreviation);

                await _divisionRepository.Update(division).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveDivisionViewModel _viewModel;

            public Command(SaveDivisionViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public string Abbreviation => _viewModel.Abbreviation;

            public int? ConferenceId => _viewModel.ConferenceId > 0 ? _viewModel.ConferenceId : null;

            public int Id => _viewModel.Id;

            public bool IsDeleted => _viewModel.IsDeleted;

            public bool IsModified => _viewModel.IsModified;

            public bool IsNew => _viewModel.IsNew;

            public int? LeagueId => _viewModel.LeagueId > 0 ? _viewModel.LeagueId : null;

            public string Name => _viewModel.Name;            
        }
    }
}
