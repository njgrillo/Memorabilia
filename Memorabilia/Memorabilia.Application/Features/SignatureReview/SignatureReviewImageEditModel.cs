namespace Memorabilia.Application.Features.SignatureReview;

public class SignatureReviewImageEditModel : EditModel
{
    public SignatureReviewImageEditModel() { }

    public SignatureReviewImageEditModel(string fileName)
    {
        FileName = fileName;
    }

    public SignatureReviewImageEditModel(Entity.SignatureReviewImage signatureReviewImage)
    {
        FileName = signatureReviewImage.FileName;
        Id = signatureReviewImage.Id;
        SignatureReviewId = signatureReviewImage.SignatureReviewId;
    }

    public string FileName { get; set; }

    public int SignatureReviewId { get; set; }
}
