namespace Memorabilia.Application.Features.SignatureIdentification;

public class SignatureIdentificationPersonEditModel : EditModel
{
	public SignatureIdentificationPersonEditModel() { }

	public SignatureIdentificationPersonEditModel(int createdUserId,
												  int signatureIdentificationId)
	{
		CreatedUserId = createdUserId;
		SignatureIdentificationId = signatureIdentificationId;
	}

    public SignatureIdentificationPersonEditModel(int createdUserId,
												  string note,
												  PersonModel personModel,
                                                  int signatureIdentificationId)
	{
        CreatedUserId = createdUserId;
        Note = note;
        Person = personModel;
        SignatureIdentificationId = signatureIdentificationId;
    }

    public SignatureIdentificationPersonEditModel(Entity.SignatureIdentificationPerson signatureIdentificationPerson)
	{
		CreateDate = signatureIdentificationPerson.CreateDate;
		CreatedUserId = signatureIdentificationPerson.CreatedUserId;
		Id = signatureIdentificationPerson.Id;
		Note = signatureIdentificationPerson.Note;
        Person = new PersonModel(signatureIdentificationPerson.Person);
        PersonId = signatureIdentificationPerson.PersonId;
		SignatureIdentificationId = signatureIdentificationPerson.SignatureIdentificationId;		
	}

	public DateTime CreateDate { get; set; }

	public int CreatedUserId { get; set; }

	public string Note { get; set; }

	public PersonModel Person { get; set; }
		= new();

	public int PersonId { get; set; }

	public int SignatureIdentificationId { get; set; }
}
