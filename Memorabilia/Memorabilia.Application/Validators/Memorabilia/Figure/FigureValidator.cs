namespace Memorabilia.Application.Validators.Memorabilia.Figure;

public class FigureValidator : AbstractValidator<SaveFigure.Command>
{
	public FigureValidator()
	{
        RuleFor(x => x.BrandId)
            .GreaterThan(0)
            .WithName("Brand")
            .WithMessage("Brand is required.");

        RuleFor(x => x.FigureTypeId)
            .GreaterThan(0)
            .NotNull()            
            .WithName("Figure Type")
            .WithMessage("Figure Type is required.");

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
            .WithMessage("Year must be greater than or equal to 1950.");

        RuleFor(x => x.Year)
            .LessThanOrEqualTo(DateTime.UtcNow.Year + 1)
            .When(x => x.Year.HasValue)
            .WithName("Year")
            .WithMessage("Year must be less than or equal to current year plus one.");
    }
}
