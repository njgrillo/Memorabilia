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
        private readonly AutographImagesEditModel _viewModel;

        public Command(AutographImagesEditModel viewModel)
        {
            _viewModel = viewModel;
        }

        public int AutographId => _viewModel.AutographId;

        public int MemorabiliaId { get; set; }

        public IEnumerable<string> FileNames 
            => _viewModel.Images.Select(image => image.FileName);            

        public string PrimaryImageFileName 
            => _viewModel.Images.SingleOrDefault(image => image.ImageTypeId == Constant.ImageType.Primary.Id)?.FileName;
    }
}
