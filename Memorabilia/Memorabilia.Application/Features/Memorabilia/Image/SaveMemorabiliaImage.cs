using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Image;

public class SaveMemorabiliaImage
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task Handle(Command command)
        {
            if (!command.FilePaths.Any())
                return;

            var memorabilia = await _memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetImages(command.FilePaths, command.PrimaryImageFilePath);

            await _memorabiliaRepository.Update(memorabilia);
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
