namespace Memorabilia.Application.Validators.Memorabilia.WristBand;

public class WristBandValidator : AbstractValidator<SaveWristBand.Command>
{
    public WristBandValidator()
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
    }

    private static bool CanHaveGameDate(SaveWristBand.Command command)
    {
        var gameStyle = Domain.Constants.GameStyleType.Find(command.GameStyleTypeId ?? 0);

        return Domain.Constants.GameStyleType.IsGameWorthly(gameStyle);
    }
}
