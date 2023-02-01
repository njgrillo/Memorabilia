﻿namespace Memorabilia.Application.Validators.Memorabilia.Shirt;

public class ShirtValidator : AbstractValidator<SaveShirt.Command>
{
	public ShirtValidator()
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

    private static bool CanHaveGameDate(SaveShirt.Command command)
    {
        var gameStyle = Domain.Constants.GameStyleType.Find(command.GameStyleTypeId ?? 0);

        return Domain.Constants.GameStyleType.IsGameWorthly(gameStyle);
    }
}
