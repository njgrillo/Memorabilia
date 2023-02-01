namespace Memorabilia.Application.Validators.Memorabilia.PinFlag;

public class PinFlagValidator : AbstractValidator<SavePinFlag.Command>
{
	public PinFlagValidator()
	{
        RuleFor(x => x.GameStyleTypeId)
            .GreaterThan(0)
            .NotNull()
            .WithName("Tournament Style")
            .WithMessage("Tournament Style is required.");
    }
}
