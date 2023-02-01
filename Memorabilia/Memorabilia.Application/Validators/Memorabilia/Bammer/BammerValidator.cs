namespace Memorabilia.Application.Validators.Memorabilia.Bammer;

public class BammerValidator : AbstractValidator<SaveBammer.Command>
{
	public BammerValidator()
	{
        RuleFor(x => x.BrandId)
            .GreaterThan(0)
            .WithName("Brand")
            .WithMessage("Brand is required.");

        RuleFor(x => x.Year)
            .GreaterThanOrEqualTo(1990)
            .When(x => x.Year.HasValue)
            .WithName("Year")
            .WithMessage("Year must be greater than or equal to 1990.");

        RuleFor(x => x.Year)
            .LessThanOrEqualTo(DateTime.UtcNow.Year + 1)
            .When(x => x.Year.HasValue)
            .WithName("Year")
            .WithMessage("Year must be less than or equal to current year plus one.");
    }
}
