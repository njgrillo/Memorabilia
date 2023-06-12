namespace Memorabilia.Application.Features.Autograph.Image;

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
            Entity.Autograph autograph = await _autographRepository.Get(command.AutographId);

            command.MemorabiliaId = autograph.MemorabiliaId;

            autograph.SetImages(command.FileNames, command.PrimaryImageFileName);

            await _autographRepository.Update(autograph);                
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly AutographImagesEditModel _editModel;

        public Command(AutographImagesEditModel editModel)
        {
            _editModel = editModel;
        }

        public int AutographId 
            => _editModel.AutographId;

        public int MemorabiliaId { get; set; }

        public IEnumerable<string> FileNames 
            => _editModel.Images
                         .Select(image => image.FileName);            

        public string PrimaryImageFileName 
            => _editModel.Images
                         .SingleOrDefault(image => image.ImageTypeId == Constant.ImageType.Primary.Id)?
                         .FileName;
    }
}
