namespace Memorabilia.Application.Features.Memorabilia.Image;

public class SaveMemorabiliaImage
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetImages(command.FileNames, command.PrimaryImageFileName);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(MemorabiliaImagesEditModel editModel) 
        : DomainCommand, ICommand
    {
        public IEnumerable<string> FileNames 
            => editModel.Images
                        .Select(image => image.FileName);

        public int MemorabiliaId 
            => editModel.MemorabiliaId;

        public string PrimaryImageFileName 
            => editModel.Images
                        .SingleOrDefault(image => image.ImageTypeId == Constant.ImageType.Primary.Id)?
                        .FileName ?? string.Empty;
    }
}
