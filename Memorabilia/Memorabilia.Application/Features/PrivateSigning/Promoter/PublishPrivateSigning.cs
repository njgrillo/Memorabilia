namespace Memorabilia.Application.Features.PrivateSigning.Promoter;

[AuthorizeByPermission(Enum.Permission.PrivateSigning)]
public record PublishPrivateSigning(int Id)
    : ICommand
{
    public class Handler(IPrivateSigningRepository privateSigningRepository)
        : CommandHandler<PublishPrivateSigning>
    {
        protected override async Task Handle(PublishPrivateSigning command)
        {
            Entity.PrivateSigning privateSigning
                = await privateSigningRepository.Get(command.Id);

            if (privateSigning is null || privateSigning.Published)
                return;

            privateSigning.Publish();

            await privateSigningRepository.Update(privateSigning);  
        }
    }
}
