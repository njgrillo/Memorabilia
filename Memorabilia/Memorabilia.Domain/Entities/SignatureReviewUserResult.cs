namespace Memorabilia.Domain.Entities;

public class SignatureReviewUserResult : Entity
{
    public SignatureReviewUserResult() { }

    public SignatureReviewUserResult(DateTime createdDate,
                                     int createdUserId,
                                     string note,
                                     int signatureReviewId,
                                     int signatureReviewResultTypeId)
    {
        CreatedDate = createdDate;
        CreatedUserId = createdUserId;
        Note = note;
        SignatureReviewId = signatureReviewId;
        SignatureReviewResultTypeId = signatureReviewResultTypeId;
    }

    public DateTime CreatedDate { get; private set; }

    public virtual User CreatedUser { get; private set; }

    public int CreatedUserId { get; private set; }

    public string Note { get; private set; }

    public virtual SignatureReview SignatureReview { get; private set; }

    public int SignatureReviewId { get; private set; }

    public int SignatureReviewResultTypeId { get; private set; }

    public void Set(string note, int signatureReviewResultTypeId)
    {
        Note = note;
        SignatureReviewResultTypeId = signatureReviewResultTypeId;
    }
}
