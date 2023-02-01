namespace Memorabilia.Application.Validators.Memorabilia.Bat;

public class BatValidator : AbstractValidator<SaveBat.Command>
{
	public BatValidator()
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

        RuleFor(x => x.Length)
            .LessThanOrEqualTo(int.MaxValue)
            .When(x => x.Length.HasValue)
            .WithName("Length")
            .WithMessage($"Length must be {int.MaxValue} or less.");

        RuleFor(x => x.SizeId)
            .GreaterThan(0)
            .WithName("Size")
            .WithMessage("Size is required.");
    }

    private static bool CanHaveGameDate(SaveBat.Command command)
    {
        var gameStyle = Domain.Constants.GameStyleType.Find(command.GameStyleTypeId ?? 0);
        var size = Domain.Constants.Size.Find(command.SizeId);

        return Domain.Constants.GameStyleType.IsGameWorthly(gameStyle) &&
               size == Domain.Constants.Size.Full;
    }
}
