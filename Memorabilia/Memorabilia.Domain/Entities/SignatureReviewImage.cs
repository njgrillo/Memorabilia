namespace Memorabilia.Domain.Entities;

public class SignatureReviewImage : DomainIdEntity
{
    public SignatureReviewImage() { }

    public SignatureReviewImage(string fileName,
                                int signatureReviewId)
    {
        FileName = fileName;
        SignatureReviewId = signatureReviewId;
    }

    public string FileName { get; private set; }

    public virtual SignatureReview SignatureReview { get; private set; }

    public int SignatureReviewId { get; private set; }
}
