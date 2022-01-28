using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Sport
{
    public class SaveSport
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly ISportRepository _sportRepository;

            public Handler(ISportRepository sportRepository)
            {
                _sportRepository = sportRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.Sport sport;

                if (command.IsNew)
                {
                    sport = new Domain.Entities.Sport(command.Name, command.AlternateName);
                    await _sportRepository.Add(sport).ConfigureAwait(false);

                    return;
                }

                sport = await _sportRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _sportRepository.Delete(sport).ConfigureAwait(false);

                    return;
                }

                sport.Set(command.Name, command.AlternateName);

                await _sportRepository.Update(sport).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveSportViewModel _viewModel;

            public Command(SaveSportViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public string AlternateName => _viewModel.AlternateName;

            public int Id => _viewModel.Id;

            public string ImagePath => _viewModel.ImagePath;

            public bool IsDeleted => _viewModel.IsDeleted;

            public bool IsModified => _viewModel.IsModified;

            public bool IsNew => _viewModel.IsNew;

            public string Name => _viewModel.Name;
        }
    }
}
