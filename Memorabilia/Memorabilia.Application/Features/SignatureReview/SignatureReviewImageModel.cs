namespace Memorabilia.Application.Features.SignatureReview;

public class SignatureReviewImageModel
{
    private readonly Entity.SignatureReviewImage _signatureReviewImage;

    public SignatureReviewImageModel() { }

    public SignatureReviewImageModel(Entity.SignatureReviewImage signatureReviewImage)
    {
        _signatureReviewImage = signatureReviewImage;
    }

    public string FileName
        => _signatureReviewImage.FileName;

    public int Id
        => _signatureReviewImage.Id;

    public int SignatureReviewId
        => _signatureReviewImage.SignatureReviewId;

    public int UserId
        => _signatureReviewImage.SignatureReview.CreatedUserId;
}
