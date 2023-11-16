namespace Memorabilia.Application.Features.Autograph.Inscriptions;

[AuthorizeByPermission(Enum.Permission.Memorabilia)]
public class SaveInscriptions
{
    public class Handler(IAutographRepository autographRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Autograph autograph = await autographRepository.Get(command.AutographId);

            autograph.RemoveInscriptions(command.DeletedIds);

            foreach (var inscription in command.Items.Where(item => !item.IsDeleted))
            {
                autograph.SetInscription(inscription.Id,
                                         inscription.InscriptionTypeId,
                                         inscription.InscriptionText);
            }

            await autographRepository.Update(autograph);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly InscriptionsEditModel _editModel;

        public Command(InscriptionsEditModel editModel)
        {
            _editModel = editModel;
            Items = _editModel.Inscriptions;
        }

        public int AutographId 
            => _editModel.AutographId;

        public int[] DeletedIds
            => Items.Where(item => item.IsDeleted)
                    .Select(item => item.Id)
                    .ToArray();

        public IEnumerable<InscriptionEditModel> Items { get; set; }
    }
}
