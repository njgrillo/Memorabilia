namespace Memorabilia.Application.Validators.Memorabilia.Soccerball;

public class SoccerballValidator : AbstractValidator<SaveSoccerball.Command>
{
	public SoccerballValidator()
	{
        RuleFor(x => x)
            .Must(CanHaveGameDate)
            .When(x => x.GameDate.HasValue)
            .WithName("Match Style")
            .WithMessage("Match Style must be Match Used when Match Date is specified.");

        RuleFor(x => x.BrandId)
            .GreaterThan(0)
            .WithName("Brand")
            .WithMessage("Brand is required.");

        RuleFor(x => x.LevelTypeId)
            .GreaterThan(0)
            .WithName("Level")
            .WithMessage("Level is required.");

        RuleFor(x => x.SizeId)
            .GreaterThan(0)
            .WithName("Size")
            .WithMessage("Size is required.");
    }

    private static bool CanHaveGameDate(SaveSoccerball.Command command)
    {
        var gameStyle = Constant.GameStyleType.Find(command.GameStyleTypeId ?? 0);
        var size = Constant.Size.Find(command.SizeId);

        return (Constant.GameStyleType.Find(command.GameStyleTypeId ?? 0)?.IsGameWorthly() ?? false) &&
               size == Constant.Size.Standard;
    }
}
