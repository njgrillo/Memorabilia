namespace Memorabilia.Application.Validators.SignatureReview;

public class SignatureReviewImageValidator 
    : AbstractValidator<SignatureReviewImageEditModel>
{
    public SignatureReviewImageValidator()
    {
        RuleFor(x => x.FileName)
            .NotEmpty()
            .NotNull()
            .WithName("FileName")
            .WithMessage("FileName is required.");

        RuleFor(x => x.FileName)
            .MaximumLength(100)
            .WithName("FileName")
            .WithMessage("FileName must be 100 characters or less.");
    }
}
