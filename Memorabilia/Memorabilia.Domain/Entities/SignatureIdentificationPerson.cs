namespace Memorabilia.Domain.Entities;

public class SignatureIdentificationPerson : DomainIdEntity
{
    public SignatureIdentificationPerson() { }

    public SignatureIdentificationPerson(DateTime createDate,
                                         int createdUserId,
                                         string note,
                                         int personId,
                                         int signatureIdentificationId)
    {
        CreateDate = createDate;
        CreatedUserId = createdUserId;
        Note = note;
        PersonId = personId;
        SignatureIdentificationId = signatureIdentificationId;
    }

    public DateTime CreateDate { get; private set; }

    public virtual User CreatedUser { get; private set; }

    public int CreatedUserId { get; private set; }

    public string Note { get; private set; }

    public virtual Person Person { get; private set; }

    public int PersonId { get; private set; }   

    public virtual SignatureIdentification SignatureIdentification { get; private set; }

    public int SignatureIdentificationId { get; private set; }

    public void Set(string note,
                    int personId)
    {
        Note = note;
        PersonId = personId;
    }
}
