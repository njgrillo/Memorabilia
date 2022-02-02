using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Memorabilia.Image
{
    public class SaveMemorabiliaImage
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

                memorabilia.AddImages(command.FilePaths);

                await _memorabiliaRepository.Update(memorabilia).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveMemorabiliaImagesViewModel _viewModel;

            public Command(SaveMemorabiliaImagesViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public IEnumerable<string> FilePaths => _viewModel.FilePaths;

            public int MemorabiliaId => _viewModel.MemorabiliaId;
        }
    }
}
