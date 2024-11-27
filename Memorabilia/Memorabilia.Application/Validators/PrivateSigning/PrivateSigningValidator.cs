namespace Memorabilia.Application.Validators.PrivateSigning;

public class PrivateSigningValidator : AbstractValidator<SavePrivateSigning.Command>
{
	public PrivateSigningValidator()
	{
        RuleFor(x => x.BeginSigningDate)
            .NotNull()
            .When(x => x.MultiDaySigning)
            .WithName("BeginSigningDate")
            .WithMessage("Begin Signing Date is required.");

        RuleFor(x => x.BeginSigningDate)
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now))
            .When(x => x.MultiDaySigning)
            .WithName("BeginSigningDate")
            .WithMessage("Begin Signing Date is required.");

        RuleFor(x => x.CreatedByUserId)
            .GreaterThan(0)
            .WithName("CreatedByUser")
            .WithMessage("Created By User is required.");

        RuleFor(x => x.EndSigningDate)
            .GreaterThan(x => x.BeginSigningDate)
            .When(x => x.MultiDaySigning && x.EndSigningDate.HasValue)
            .WithName("EndSigningDate")
            .WithMessage("End Signing Date must be greater than to Start Signing Date.");

        RuleFor(x => x.Note)
            .MaximumLength(3000)
            .WithName("Note")
            .WithMessage("Note must be 3000 characters or less.");

        RuleFor(x => x.PromoterImageFileName)
           .MaximumLength(100)
           .WithName("PromoterImageFileName")
           .WithMessage("Promoter Image File Name must be 100 characters or less.");

        RuleFor(x => x.SubmissionDeadlineDate)
            .NotNull()
            .WithName("SubmissionDeadlineDate")
            .WithMessage("Submission Deadline Date is required.");

        RuleFor(x => x.SubmissionDeadlineDate)
            .GreaterThanOrEqualTo(DateTime.Now)
            .WithName("SubmissionDeadlineDate")
            .WithMessage("Submission Deadline Date cannot be in the past.");

        RuleForEach(x => x.AuthenticationCompanies)
            .SetValidator(new PrivateSigningAuthenticationCompanyValidator());

        RuleForEach(x => x.CustomPricing)
            .SetValidator(new PrivateSigningPriceValidator());

        RuleForEach(x => x.ExcludedItems)
            .SetValidator(new PrivateSigningExcludedItemTypeValidator());

        RuleForEach(x => x.PaymentOptions)
            .SetValidator(new PrivateSigningPaymentOptionValidator());

        RuleForEach(x => x.People)
            .SetValidator(new PrivateSigningPersonValidator());

        RuleForEach(x => x.Pricing)
            .SetValidator(new PrivateSigningPriceValidator());
    }
}
