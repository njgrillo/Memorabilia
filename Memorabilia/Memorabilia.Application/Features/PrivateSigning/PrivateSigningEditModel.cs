namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningEditModel : EditModel
{
	public PrivateSigningEditModel() { }

    public PrivateSigningEditModel(Entity.PrivateSigning privateSigning)
    {
        CreatedByUserId = privateSigning.CreatedUserId;
        CreatedDate = privateSigning.CreatedDate;
        Id = privateSigning.Id;
        Note = privateSigning.Note;
        SigningDate = privateSigning.SigningDate;
        SubmissionDeadlineDate = privateSigning.SubmissionDeadlineDate;
    }

    public int CreatedByUserId { get; set; }

    public DateTime CreatedDate { get; set; }

	public string Note { get; set; }

    public DateTime SigningDate { get; set; }

    public DateTime SubmissionDeadlineDate { get; set; }
}
