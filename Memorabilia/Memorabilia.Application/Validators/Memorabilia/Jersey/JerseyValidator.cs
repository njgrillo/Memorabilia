namespace Memorabilia.Application.Validators.Memorabilia.Jersey;

public class JerseyValidator : AbstractValidator<SaveJersey.Command>
{
	public JerseyValidator()
	{
        RuleFor(x => x)
            .Must(CanHaveGameDate)
            .When(x => x.GameDate.HasValue)
            .WithName("Game Style")
            .WithMessage("Game Style must be Game Issued or Game Used when Game Date is specified.");

        RuleFor(x => x.BrandId)
            .GreaterThan(0)
            .WithName("Brand")
            .WithMessage("Brand is required.");        

        RuleFor(x => x.LevelTypeId)
            .GreaterThan(0)
            .WithName("Level")
            .WithMessage("Level is required.");

        RuleFor(x => x.QualityTypeId)
            .GreaterThan(0)
            .WithName("Quality")
            .WithMessage("Quality is required.");

        RuleFor(x => x.SizeId)
            .GreaterThan(0)
            .WithName("Size")
            .WithMessage("Size is required.");

        RuleFor(x => x.StyleTypeId)
            .GreaterThan(0)
            .WithName("Style")
            .WithMessage("Style is required.");

        RuleFor(x => x.TypeId)
            .GreaterThan(0)
            .WithName("Type")
            .WithMessage("Type is required.");
    }

    private static bool CanHaveGameDate(SaveJersey.Command command)
    {
        var jerseyQualityType = Constant.JerseyQualityType.Find(command.QualityTypeId);

        return (Constant.GameStyleType.Find(command.GameStyleTypeId ?? 0)?.IsGameWorthly() ?? false) &&
               jerseyQualityType == Constant.JerseyQualityType.Authentic;
    }
}
