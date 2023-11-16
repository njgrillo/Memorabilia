namespace Memorabilia.Application.Features.SignatureIdentification;

[AuthorizeByPermission(Enum.Permission.EditSignatureIdentification)]
public class SaveSignatureIdentificationPerson
{
    public class Handler(ISignatureIdentificationRepository signatureIdentificationRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.SignatureIdentification signatureIdentification
                = await signatureIdentificationRepository.Get(command.SignatureIdentificationId);

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

            await signatureIdentificationRepository.Update(signatureIdentification);
        }
    }

    public class Command(SignatureIdentificationPersonEditModel signatureIdentificationPersonEditModel) 
        : DomainCommand, ICommand
    {
        public DateTime CreatedDate
            => DateTime.UtcNow;

        public int CreatedUserId
            => signatureIdentificationPersonEditModel.CreatedUserId;

        public string Note
            => signatureIdentificationPersonEditModel.Note;

        public int PersonId
            => signatureIdentificationPersonEditModel.Person.Id;

        public int SignatureIdentificationId
            => signatureIdentificationPersonEditModel.SignatureIdentificationId;
    }
}
