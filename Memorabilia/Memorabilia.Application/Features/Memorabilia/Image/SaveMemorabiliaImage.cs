using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using Memorabilia.Domain.Constants;
using System.Collections.Generic;
using System.Linq;
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

                memorabilia.SetImages(command.FilePaths, command.PrimaryImageFilePath);

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

            public IEnumerable<string> FilePaths => _viewModel.Images.Select(image => image.FilePath);

            public int MemorabiliaId => _viewModel.MemorabiliaId;

            public string PrimaryImageFilePath => _viewModel.Images.Single(image => image.ImageTypeId == ImageType.Primary.Id).FilePath;
        }
    }
}
