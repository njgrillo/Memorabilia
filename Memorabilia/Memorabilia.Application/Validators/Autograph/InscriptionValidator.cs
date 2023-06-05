namespace Memorabilia.Application.Validators.Autograph;

public class InscriptionValidator : AbstractValidator<InscriptionEditModel>
{
	public InscriptionValidator()
	{
        RuleFor(x => x.InscriptionText)
            .NotEmpty() 
            .NotNull()
            .WithName("Inscription Text")
            .WithMessage("Inscription Text is required.");

        RuleFor(x => x.InscriptionText)
            .MaximumLength(1000)
            .WithName("Inscription Text")
            .WithMessage("Inscription Text must be 1,000 characters or less.");

        RuleFor(x => x.InscriptionTypeId)
            .GreaterThan(0)
            .WithName("Inscription Type")
            .WithMessage("Inscription Type is required.");
    }
}
