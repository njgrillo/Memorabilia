namespace Memorabilia.Application.Validators.Memorabilia.Pylon;

public class PylonValidator : AbstractValidator<SavePylon.Command>
{
	public PylonValidator()
	{
        RuleFor(x => x)
            .Must(CanHaveGameDate)
            .When(x => x.GameDate.HasValue)
            .WithName("Game Style")
            .WithMessage("Game Style must be Game Issued or Game Used when Game Date is specified.");

        RuleFor(x => x.LevelTypeId)
            .GreaterThan(0)
            .WithName("Level")
            .WithMessage("Level is required.");

        RuleFor(x => x.SizeId)
            .GreaterThan(0)
            .WithName("Size")
            .WithMessage("Size is required.");
    }

    private static bool CanHaveGameDate(SavePylon.Command command)
    {
        var size = Domain.Constants.Size.Find(command.SizeId);

        return (Domain.Constants.GameStyleType.Find(command.GameStyleTypeId ?? 0)?.IsGameWorthly() ?? false) &&
               size == Domain.Constants.Size.Standard;
    }
}
