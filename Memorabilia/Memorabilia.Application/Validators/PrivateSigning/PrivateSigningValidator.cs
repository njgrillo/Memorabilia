namespace Memorabilia.Application.Validators.PrivateSigning;

public class PrivateSigningValidator : AbstractValidator<SavePrivateSigning.Command>
{
	public PrivateSigningValidator()
	{
        RuleFor(x => x.CreatedByUserId)
            .GreaterThan(0)
            .WithName("CreatedByUser")
            .WithMessage("Created By User is required.");

        RuleFor(x => x.Note)
            .MaximumLength(3000)
            .WithName("Note")
            .WithMessage("Note must be 3000 characters or less.");

        RuleFor(x => x.PromoterImageFileName)
           .MaximumLength(100)
           .WithName("PromoterImageFileName")
           .WithMessage("Promoter Image File Name must be 100 characters or less.");

        RuleFor(x => x.SigningDate)
            .NotNull()
            .WithName("SigningDate")
            .WithMessage("Signing Date is required.");

        RuleFor(x => x.SubmissionDeadlineDate)
            .NotNull()
            .WithName("SubmissionDeadlineDate")
            .WithMessage("Submission Deadline Date is required.");

        RuleForEach(x => x.AuthenticationCompanies)
            .SetValidator(new PrivateSigningAuthenticationCompanyValidator());

        RuleForEach(x => x.People)
            .SetValidator(new PrivateSigningPersonValidator());
    }
}
