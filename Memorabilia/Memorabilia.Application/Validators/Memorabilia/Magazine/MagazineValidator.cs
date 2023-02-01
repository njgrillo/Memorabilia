namespace Memorabilia.Application.Validators.Memorabilia.Magazine;

public class MagazineValidator : AbstractValidator<SaveMagazine.Command>
{
	public MagazineValidator()
	{
        RuleFor(x => x.BrandId)
            .GreaterThan(0)
            .WithName("Brand")
            .WithMessage("Brand is required.");

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

        RuleFor(x => x.OrientationId)
            .GreaterThan(0)
            .WithName("Orientation")
            .WithMessage("Orientation is required.");

        RuleFor(x => x.SizeId)
            .GreaterThan(0)
            .WithName("Size")
            .WithMessage("Size is required.");
    }
}
