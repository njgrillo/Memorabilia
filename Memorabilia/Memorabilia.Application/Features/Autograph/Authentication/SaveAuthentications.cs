namespace Memorabilia.Application.Features.Autograph.Authentication;

public class SaveAuthentications
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

            autograph.RemoveAuthentications(command.DeletedIds);

            foreach (var authentication in command.Items.Where(item => !item.IsDeleted))
            {
                autograph.SetAuthentication(authentication.Id,
                                            authentication.AuthenticationCompanyId,
                                            authentication.HasCertificationCard,
                                            authentication.HasHologram,
                                            authentication.HasLetter,
                                            authentication.Verification,
                                            authentication.Witnessed);
            }

            await _autographRepository.Update(autograph);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly AuthenticationsEditModel _viewModel;

        public Command(AuthenticationsEditModel viewModel)
        {
            _viewModel = viewModel;
            Items = _viewModel.Authentications;
        }

        public int AutographId => _viewModel.AutographId;

        public int[] DeletedIds => Items.Where(item => item.IsDeleted).Select(item => item.Id).ToArray();

        public IEnumerable<AuthenticationEditModel> Items { get; set; }
    }
}
