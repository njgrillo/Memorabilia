using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using Memorabilia.Domain.Constants;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Autograph.Image
{
    public class SaveAutographImage
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IAutographRepository _autographRepository;

            public Handler(IAutographRepository autographRepository)
            {
                _autographRepository = autographRepository;
            }

            protected override async Task Handle(Command command)
            {
                if (!command.FilePaths.Any())
                    return;

                var autograph = await _autographRepository.Get(command.AutographId).ConfigureAwait(false);

                autograph.SetImages(command.FilePaths, command.PrimaryImageFilePath);

                await _autographRepository.Update(autograph).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveAutographImagesViewModel _viewModel;

            public Command(SaveAutographImagesViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public int AutographId => _viewModel.AutographId;

            public IEnumerable<string> FilePaths => _viewModel.Images.Select(image => image.FilePath);            

            public string PrimaryImageFilePath => _viewModel.Images.Single(image => image.ImageTypeId == ImageType.Primary.Id).FilePath;
        }
    }
}
