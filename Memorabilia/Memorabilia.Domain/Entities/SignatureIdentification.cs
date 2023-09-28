namespace Memorabilia.Domain.Entities;

public class SignatureIdentification : Framework.Library.Domain.Entity.DomainEntity
{
    public SignatureIdentification() { }

    public SignatureIdentification(DateTime createdDate,
                                   int createdUserId,
                                   string note)
    {
        CreatedDate = createdDate;
        CreatedUserId = createdUserId;
        Note = note;
    }

    public SignatureIdentification(SignatureIdentification signatureIdentification)
    {
        CreatedDate = signatureIdentification.CreatedDate;
        CreatedUser = signatureIdentification.CreatedUser;
        CreatedUserId = signatureIdentification.CreatedUserId;
        Id = signatureIdentification.Id;
        Images = signatureIdentification.Images;
        Note = signatureIdentification.Note;
        People = signatureIdentification.People;
    }

    public DateTime CreatedDate { get; private set; }

    public virtual User CreatedUser { get; private set; }

    public int CreatedUserId { get; private set; }

    public virtual List<SignatureIdentificationImage> Images { get; private set; }

    public string Note { get; private set; }

    public virtual List<SignatureIdentificationPerson> People { get; private set; }

    public void AddImage(string fileName)
    {
        Images ??= new();

        Images.Add(new SignatureIdentificationImage(fileName, Id));
    }

    public void AddPerson(DateTime createdDate,
                          int createdUserId,
                          string note,
                          int personId)
    {
        People ??= new();

        People.Add(new SignatureIdentificationPerson(createdDate,
                                                     createdUserId,
                                                     note,
                                                     personId,
                                                     Id));
    }

    public void SetPerson(int id, string note, int personId)
    {
        SignatureIdentificationPerson personToEdit 
            = People.Single(person => person.Id == id);

        personToEdit.Set(note, personId);
    }
}
