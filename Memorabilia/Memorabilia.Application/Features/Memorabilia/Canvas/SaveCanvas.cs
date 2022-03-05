using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Memorabilia.Canvas
{
    public class SaveCanvas
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

                memorabilia.SetCanvas(command.BrandId,
                                      command.Framed,
                                      command.OrientationId,
                                      command.PersonIds,
                                      command.SizeId,
                                      command.SportIds,
                                      command.Stretched,
                                      command.TeamIds);

                await _memorabiliaRepository.Update(memorabilia).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveCanvasViewModel _viewModel;

            public Command(SaveCanvasViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public int BrandId => _viewModel.BrandId;

            public bool Framed => _viewModel.Framed;

            public int MemorabiliaId => _viewModel.MemorabiliaId;

            public int OrientationId => _viewModel.OrientationId;

            public int[] PersonIds => _viewModel.People.Select(person => person.Id).ToArray();

            public int SizeId => _viewModel.SizeId;

            public int[] SportIds => _viewModel.Sports.Select(team => team.Id).ToArray();

            public bool Stretched => _viewModel.Stretched;

            public int[] TeamIds => _viewModel.Teams.Select(team => team.Id).ToArray();
        }
    }
}
