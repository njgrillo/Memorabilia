namespace Memorabilia.Domain.Entities;

public class PrivateSigning : Framework.Library.Domain.Entity.DomainEntity
{
    public PrivateSigning() { }

    public PrivateSigning(DateTime createdDate,
                          int createdUserId,
                          string note,
                          DateTime signingDate,
                          DateTime submissionDeadlineDate)
    {
        CreatedDate = createdDate;
        CreatedUserId = createdUserId;
        Note = note;
        SigningDate = signingDate;
        SubmissionDeadlineDate = submissionDeadlineDate;
    }

    public PrivateSigning(PrivateSigning privateSigning)
    {
        AuthenticationCompanies = privateSigning.AuthenticationCompanies;
        CreatedDate = privateSigning.CreatedDate;
        CreatedUser = privateSigning.CreatedUser;
        CreatedUserId = privateSigning.CreatedUserId;
        Note = privateSigning.Note;
        People = privateSigning.People;
        SigningDate = privateSigning.SigningDate;
        SubmissionDeadlineDate = privateSigning.SubmissionDeadlineDate;
    }

    public virtual List<PrivateSigningAuthenticationCompany> AuthenticationCompanies { get; private set; }

    public DateTime CreatedDate { get; private set; }

    public virtual User CreatedUser { get; private set; }

    public int CreatedUserId { get; private set; }

    public string Note { get; private set; }

    public virtual List<PrivateSigningPerson> People { get; private set; }

    public DateTime SigningDate { get; private set; }

    public DateTime SubmissionDeadlineDate { get; private set; }

    public void Set(string note,
                    DateTime signingDate,
                    DateTime submissionDeadlineDate)
    {
        Note = note;
        SigningDate = signingDate;
        SubmissionDeadlineDate = submissionDeadlineDate;
    }
}
