namespace Memorabilia.Application.Validators.Memorabilia.TennisRacket;

public class TennisRacketValidator : AbstractValidator<SaveTennisRacket.Command>
{
    public TennisRacketValidator()
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

    private static bool CanHaveGameDate(SaveTennisRacket.Command command)
    {
        var gameStyle = Domain.Constants.GameStyleType.Find(command.GameStyleTypeId ?? 0);
        var size = Domain.Constants.Size.Find(command.SizeId);

        return (Domain.Constants.GameStyleType.Find(command.GameStyleTypeId ?? 0)?.IsGameWorthly() ?? false) &&
               size == Domain.Constants.Size.Standard;
    }
}
