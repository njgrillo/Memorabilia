namespace Memorabilia.Application.Validators.Memorabilia.JerseyNumber;

public class JerseyNumberValidator : AbstractValidator<SaveJerseyNumber.Command>
{
	public JerseyNumberValidator()
	{
        RuleFor(x => x.Number)
            .NotNull()
            .WithName("Number")
            .WithMessage("Number is required.");

        RuleFor(x => x.Number)
            .GreaterThanOrEqualTo(0)
            .When(x => x.Number.HasValue)
            .WithName("Number")
            .WithMessage("Number must be 0 or greater.");

        RuleFor(x => x.Number)
            .LessThanOrEqualTo(99)
            .When(x => x.Number.HasValue)
            .WithName("Number")
            .WithMessage("Number must be 99 or less.");
    }
}
