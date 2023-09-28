namespace Memorabilia.Application.Features.SignatureIdentification;

public class SaveSignatureIdentificationPerson
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
                = await _signatureIdentificationRepository.Get(command.SignatureIdentificationId);

            Entity.SignatureIdentificationPerson signatureIdentificationPerson
                = signatureIdentification.People.SingleOrDefault(person => person.CreatedUserId == command.CreatedUserId);

            if (signatureIdentificationPerson == null)
            {
                signatureIdentification.AddPerson(command.CreatedDate,
                                                  command.CreatedUserId,
                                                  command.Note,
                                                  command.PersonId);
            }
            else
            {
                signatureIdentification.SetPerson(signatureIdentificationPerson.Id,
                                                  command.Note, 
                                                  command.PersonId);
            }            

            await _signatureIdentificationRepository.Update(signatureIdentification);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SignatureIdentificationPersonEditModel _signatureIdentificationPersonEditModel;

        public Command(SignatureIdentificationPersonEditModel signatureIdentificationPersonEditModel)
        {
            _signatureIdentificationPersonEditModel = signatureIdentificationPersonEditModel;
        }

        public DateTime CreatedDate
            => DateTime.UtcNow;

        public int CreatedUserId
            => _signatureIdentificationPersonEditModel.CreatedUserId;

        public string Note
            => _signatureIdentificationPersonEditModel.Note;

        public int PersonId
            => _signatureIdentificationPersonEditModel.Person.Id;

        public int SignatureIdentificationId
            => _signatureIdentificationPersonEditModel.SignatureIdentificationId;
    }
}
