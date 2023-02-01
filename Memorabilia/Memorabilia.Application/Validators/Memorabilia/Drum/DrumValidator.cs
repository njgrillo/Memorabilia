namespace Memorabilia.Application.Validators.Memorabilia.Drum;

public class DrumValidator : AbstractValidator<SaveDrum.Command>
{
	public DrumValidator()
	{
        RuleFor(x => x.BrandId)
            .GreaterThan(0)
            .WithName("Brand")
            .WithMessage("Brand is required.");
    }
}
