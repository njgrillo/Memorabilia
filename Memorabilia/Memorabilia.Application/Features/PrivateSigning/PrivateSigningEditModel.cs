namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningEditModel : EditModel
{
	public PrivateSigningEditModel() { }

    public PrivateSigningEditModel(Entity.User createdUser)
    {
        CreatedByUser = new UserModel(createdUser);
        CreatedByUserId = createdUser.Id;
    }

    public PrivateSigningEditModel(Entity.PrivateSigning privateSigning)
    {
        CreatedByUserId = privateSigning.CreatedUserId;
        CreatedDate = privateSigning.CreatedDate;
        Id = privateSigning.Id;
        Note = privateSigning.Note;        
        SigningDate = privateSigning.SigningDate;
        SubmissionDeadlineDate = privateSigning.SubmissionDeadlineDate;

        AuthenticationCompanies = privateSigning.AuthenticationCompanies
                                                .Select(company => new PrivateSigningAuthenticationCompanyEditModel(company))
                                                .ToList();

        People = privateSigning.People
                               .Select(person => new PrivateSigningPersonEditModel(person))
                               .ToList();
    }

    public List<PrivateSigningAuthenticationCompanyEditModel> AuthenticationCompanies { get; set; }
        = new();

    public UserModel CreatedByUser { get; set; }

    public int CreatedByUserId { get; set; }

    public DateTime CreatedDate { get; set; }

	public string Note { get; set; }

    public List<PrivateSigningPersonEditModel> People { get; set; }
        = new();

    public DateTime? SigningDate { get; set; }

    public DateTime? SubmissionDeadlineDate { get; set; }
}
