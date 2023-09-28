namespace Memorabilia.Application.Features.SignatureReview;

public class SignatureReviewsModel : Model
{
    public SignatureReviewsModel() { }

    public SignatureReviewsModel(Entity.SignatureReview[] signatureReviews)
    {
        SignatureReviews
            = signatureReviews.Select(signatureReview => new SignatureReviewModel(signatureReview))
                              .ToList();
    }

    public SignatureReviewsModel(Entity.SignatureReview[] signatureReviews,
                                 PageInfoResult pageInfo)
    {
        SignatureReviews
            = signatureReviews.Select(signatureReview => new SignatureReviewModel(signatureReview))
                              .ToList();

        PageInfo = pageInfo;
    }

    public List<SignatureReviewModel> SignatureReviews { get; set; }
        = new();
}
