namespace Memorabilia.Application.Validators.Memorabilia.Bobblehead;

public class BobbleheadValidator : AbstractValidator<SaveBobblehead.Command>
{
	public BobbleheadValidator()
	{
        RuleFor(x => x.LevelTypeId)
            .GreaterThan(0)
            .WithName("Level")
            .WithMessage("Level is required.");

        RuleFor(x => x.SizeId)
            .GreaterThan(0)
            .WithName("Size")
            .WithMessage("Size is required.");

        RuleFor(x => x.Year)
            .GreaterThanOrEqualTo(1950)
            .When(x => x.Year.HasValue)
            .WithName("Year")
            .WithMessage($"Year must be 1950 or greater.");

        RuleFor(x => x.Year)
            .LessThanOrEqualTo(DateTime.UtcNow.Year + 1)
            .When(x => x.Year.HasValue)
            .WithName("Year")
            .WithMessage($"Year must be {DateTime.UtcNow.Year + 1} or less.");
    }
}
