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
            var memorabilia = await _memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetImages(command.FileNames, command.PrimaryImageFileName);

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

        public IEnumerable<string> FileNames => _viewModel.Images.Select(image => image.FileName);

        public int MemorabiliaId => _viewModel.MemorabiliaId;

        public string PrimaryImageFileName => _viewModel.Images.SingleOrDefault(image => image.ImageTypeId == ImageType.Primary.Id)?.FileName;
    }
}
