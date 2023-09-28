namespace Memorabilia.Application.Features.SignatureIdentification;

public class SaveSignatureIdentification
{
    public class Handler : CommandHandler<Command>
    {
        private readonly ISignatureIdentificationRepository _signatureIdentificationRepository;

        public Handler(ISignatureIdentificationRepository signatureIdentificationRepository)
        {
            _signatureIdentificationRepository = signatureIdentificationRepository;
        }

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

            await _signatureIdentificationRepository.Add(signatureIdentification);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SignatureIdentificationEditModel _signatureIdentificationEditModel;

        public Command(SignatureIdentificationEditModel signatureIdentificationEditModel)
        {
            _signatureIdentificationEditModel = signatureIdentificationEditModel;
        }

        public DateTime CreatedDate
            => DateTime.UtcNow;
        
        public int CreatedUserId
            => _signatureIdentificationEditModel.CreatedUserId;

        public SignatureIdentificationImageEditModel[] Images
            => _signatureIdentificationEditModel.Images.ToArray();

        public string Note
            => _signatureIdentificationEditModel.Note;
    }
}
