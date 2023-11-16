namespace Memorabilia.Application.Validators.SignatureReview;

public class SignatureReviewValidator 
    : AbstractValidator<SaveSignatureReview.Command>
{
    public SignatureReviewValidator()
    {
        RuleFor(x => x.CreatedUserId)
            .GreaterThan(0)
            .WithName("CreatedUserId")
            .WithMessage("CreatedUserId is required.");

        RuleFor(x => x.PersonId)
            .GreaterThan(0)
            .WithName("PersonId")
            .WithMessage("Person is required.");

        RuleFor(x => x)
            .Must(x => x.Images.HasAny())
            .WithName("Images")
            .WithMessage("Must upload at least one image.");

        RuleForEach(x => x.Images)
            .SetValidator(new SignatureReviewImageValidator());
    }
}
