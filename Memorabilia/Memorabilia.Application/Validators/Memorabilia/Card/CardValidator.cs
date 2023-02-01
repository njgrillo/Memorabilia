namespace Memorabilia.Application.Validators.Memorabilia.Card;

public class CardValidator : AbstractValidator<SaveCard.Command>
{
	public CardValidator()
	{
        RuleFor(x => x.BrandId)
            .GreaterThan(0)
            .WithName("Brand")
            .WithMessage("Brand is required.");

        RuleFor(x => x.LevelTypeId)
            .GreaterThan(0)
            .WithName("Level")
            .WithMessage("Level is required.");

        RuleFor(x => x.OrientationId)
            .GreaterThan(0)
            .WithName("Orientation")
            .WithMessage("Orientation is required.");

        RuleFor(x => x.SizeId)
            .GreaterThan(0)
            .WithName("Size")
            .WithMessage("Size is required.");

        RuleFor(x => x.Year)
            .GreaterThanOrEqualTo(1868)
            .When(x => x.Year.HasValue)
            .WithName("Year")
            .WithMessage("Year must be 1868 or after.");

        RuleFor(x => x.Year)
            .LessThanOrEqualTo(DateTime.UtcNow.Year + 1)
            .When(x => x.Year.HasValue)
            .WithName("Year")
            .WithMessage($"Year must be {DateTime.UtcNow.Year + 1} or before.");
    }
}
