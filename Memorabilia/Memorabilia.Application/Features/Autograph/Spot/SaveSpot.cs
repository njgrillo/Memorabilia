namespace Memorabilia.Application.Features.Autograph.Spot;

public class SaveSpot
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

            autograph.SetSpot(command.SpotId);

            await _autographRepository.Update(autograph);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SpotEditModel _viewModel;

        public Command(SpotEditModel viewModel)
        {
            _viewModel = viewModel;
        }

        public int AutographId => _viewModel.AutographId;

        public int SpotId => _viewModel.SpotId;
    }
}
