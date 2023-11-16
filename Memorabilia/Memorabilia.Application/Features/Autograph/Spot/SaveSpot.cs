namespace Memorabilia.Application.Features.Autograph.Spot;

[AuthorizeByPermission(Enum.Permission.Memorabilia)]
public class SaveSpot
{
    public class Handler(IAutographRepository autographRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Autograph autograph = await autographRepository.Get(command.AutographId);

            autograph.SetSpot(command.SpotId);

            await autographRepository.Update(autograph);
        }
    }

    public class Command(SpotEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int AutographId 
            => editModel.AutographId;

        public int SpotId 
            => editModel.SpotId;
    }
}
