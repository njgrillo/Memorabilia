namespace Memorabilia.Application.Validators.Memorabilia.FirstDayCover;

public class FirstDayCoverValidator : AbstractValidator<SaveFirstDayCover.Command>
{
	public FirstDayCoverValidator()
	{
        RuleFor(x => x.Date)
            .GreaterThanOrEqualTo(DateTime.MinValue)
            .When(x => x.Date.HasValue)
            .WithName("Date")
            .WithMessage($"Date cannot be before {DateTime.MinValue}.");

        RuleFor(x => x.Date)
            .LessThanOrEqualTo(DateTime.UtcNow)
            .When(x => x.Date.HasValue)
            .WithName("Date")
            .WithMessage("Date cannot be in the future.");

        RuleFor(x => x.SizeId)
            .GreaterThan(0)
            .WithName("Size")
            .WithMessage("Size is required.");
    }
}
