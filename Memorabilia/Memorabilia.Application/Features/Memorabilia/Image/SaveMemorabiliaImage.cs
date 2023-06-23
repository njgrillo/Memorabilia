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
            Entity.Memorabilia memorabilia = await _memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetImages(command.FileNames, command.PrimaryImageFileName);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly MemorabiliaImagesEditModel _editModel;

        public Command(MemorabiliaImagesEditModel editModel)
        {
            _editModel = editModel;
        }

        public IEnumerable<string> FileNames 
            => _editModel.Images
                         .Select(image => image.FileName);

        public int MemorabiliaId 
            => _editModel.MemorabiliaId;

        public string PrimaryImageFileName 
            => _editModel.Images
                         .SingleOrDefault(image => image.ImageTypeId == Constant.ImageType.Primary.Id)?
                         .FileName ?? string.Empty;
    }
}
