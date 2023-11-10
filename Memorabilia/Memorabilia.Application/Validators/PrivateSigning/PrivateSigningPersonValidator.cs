namespace Memorabilia.Application.Validators.PrivateSigning;

public class PrivateSigningPersonValidator : AbstractValidator<PrivateSigningPersonEditModel>
{
	public PrivateSigningPersonValidator()
	{
        RuleFor(x => x.Note)
            .MaximumLength(3000)
            .WithName("Note")
            .WithMessage("Note must be 3000 characters or less.");

        RuleFor(x => x.SpotsAvailable)
           .GreaterThanOrEqualTo(x => x.SpotsConfirmed.Value)
           .When(x => x.SpotsConfirmed.HasValue)
           .WithName("Spots Available")
           .WithMessage("Spots Available must be greater than or equal to Spots Confirmed.");

        RuleFor(x => x.SpotsAvailable)
           .GreaterThanOrEqualTo(x => x.SpotsReserved.Value)
           .When(x => x.SpotsReserved.HasValue)
           .WithName("Spots Available")
           .WithMessage("Spots Available must be greater than or equal to Spots Reserved.");
    }
}
