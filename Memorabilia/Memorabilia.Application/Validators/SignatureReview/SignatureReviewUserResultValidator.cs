namespace Memorabilia.Application.Validators.SignatureReview;

public class SignatureReviewUserResultValidator 
    : AbstractValidator<SaveSignatureReviewUserResult.Command>
{
    public SignatureReviewUserResultValidator()
    {
        RuleFor(x => x.CreatedUserId)
            .GreaterThan(0)
            .WithName("CreatedUserId")
            .WithMessage("CreatedUserId is required.");

        RuleFor(x => x.SignatureReviewId)
            .GreaterThan(0)
            .WithName("SignatureReviewId")
            .WithMessage("Signature Review is required.");

        RuleFor(x => x.SignatureReviewResultTypeId)
            .GreaterThan(0)
            .WithName("SignatureReviewResultTypeId")
            .WithMessage("Signature Review Result Type is required.");
    }
}
