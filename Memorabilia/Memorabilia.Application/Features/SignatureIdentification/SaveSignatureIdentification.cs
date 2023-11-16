namespace Memorabilia.Application.Features.SignatureIdentification;

[AuthorizeByPermission(Enum.Permission.EditSignatureIdentification)]
public class SaveSignatureIdentification
{
    public class Handler(ISignatureIdentificationRepository signatureIdentificationRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.SignatureIdentification signatureIdentification
                = new(command.CreatedDate,
                      command.CreatedUserId,
                      command.Note);

            foreach (SignatureIdentificationImageEditModel image in command.Images)
            {
                signatureIdentification.AddImage(image.FileName);
            }

            await signatureIdentificationRepository.Add(signatureIdentification);
        }
    }

    public class Command(SignatureIdentificationEditModel signatureIdentificationEditModel) 
        : DomainCommand, ICommand
    {
        public DateTime CreatedDate
            => DateTime.UtcNow;
        
        public int CreatedUserId
            => signatureIdentificationEditModel.CreatedUserId;

        public SignatureIdentificationImageEditModel[] Images
            => signatureIdentificationEditModel.Images.ToArray();

        public string Note
            => signatureIdentificationEditModel.Note;
    }
}
