namespace Memorabilia.Application.Features.Autograph.Image;

[AuthorizeByPermission(Enum.Permission.Memorabilia)]
public class SaveAutographImage
{
    public class Handler(IAutographRepository autographRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {     
            Entity.Autograph autograph = await autographRepository.Get(command.AutographId);

            command.MemorabiliaId = autograph.MemorabiliaId;

            autograph.SetImages(command.FileNames, command.PrimaryImageFileName);

            await autographRepository.Update(autograph);                
        }
    }

    public class Command(AutographImagesEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int AutographId 
            => editModel.AutographId;        

        public IEnumerable<string> FileNames 
            => editModel.Images
                        .Select(image => image.FileName);

        public int MemorabiliaId { get; set; }

        public string PrimaryImageFileName 
            => editModel.Images
                        .SingleOrDefault(image => image.ImageTypeId == Constant.ImageType.Primary.Id)?
                        .FileName;
    }
}
