namespace Memorabilia.Application.Features.Autograph.Authentication;

[AuthorizeByPermission(Enum.Permission.Memorabilia)]
public class SaveAuthentications
{
    public class Handler(IAutographRepository autographRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Autograph autograph = await autographRepository.Get(command.AutographId);

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

            await autographRepository.Update(autograph);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly AuthenticationsEditModel _editModel;

        public Command(AuthenticationsEditModel editModel)
        {
            _editModel = editModel;
            Items = _editModel.Authentications;
        }

        public int AutographId 
            => _editModel.AutographId;

        public int[] DeletedIds 
            => Items.Where(item => item.IsDeleted)
                    .Select(item => item.Id)
                    .ToArray();

        public IEnumerable<AuthenticationEditModel> Items { get; set; }
    }
}
