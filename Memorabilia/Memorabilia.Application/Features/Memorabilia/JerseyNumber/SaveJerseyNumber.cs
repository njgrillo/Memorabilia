using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Memorabilia.JerseyNumber
{
    public class SaveJerseyNumber
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IMemorabiliaRepository _memorabiliaRepository;

            public Handler(IMemorabiliaRepository memorabiliaRepository)
            {
                _memorabiliaRepository = memorabiliaRepository;
            }

            protected override async Task Handle(Command command)
            {
                var memorabilia = await _memorabiliaRepository.Get(command.MemorabiliaId).ConfigureAwait(false);

                memorabilia.SetJerseyNumber(command.SportId, command.TeamId);

                await _memorabiliaRepository.Update(memorabilia).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveJerseyNumberViewModel _viewModel;

            public Command(SaveJerseyNumberViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public int MemorabiliaId => _viewModel.MemorabiliaId;

            public int? SportId => _viewModel.Sport?.Id > 0 ? _viewModel.Sport?.Id : null;

            public int? TeamId => _viewModel.Team?.Id > 0 ? _viewModel.Team?.Id : null;
        }
    }
}
