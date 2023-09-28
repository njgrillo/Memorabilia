namespace Memorabilia.Application.Features.SignatureIdentification;

public class SignatureIdentificationPersonModel
{
    private readonly Entity.SignatureIdentificationPerson _signatureIdentificationPerson;

    public SignatureIdentificationPersonModel() { }

    public SignatureIdentificationPersonModel(Entity.SignatureIdentificationPerson signatureIdentificationPerson)
    {
        _signatureIdentificationPerson = signatureIdentificationPerson;
    }

    public DateTime CreateDate
        => _signatureIdentificationPerson.CreateDate;

    public UserModel CreatedUser
        => new(_signatureIdentificationPerson.CreatedUser);

    public int CreatedUserId
        => _signatureIdentificationPerson.CreatedUserId;

    public string Note
        => _signatureIdentificationPerson.Note;

    public PersonModel Person
        => new(_signatureIdentificationPerson.Person);

    public int PersonId
        => _signatureIdentificationPerson.PersonId;

    public int SignatureIdentificationId
        => _signatureIdentificationPerson.SignatureIdentificationId;
}
