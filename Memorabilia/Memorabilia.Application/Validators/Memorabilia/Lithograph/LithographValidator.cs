namespace Memorabilia.Application.Validators.Memorabilia.Lithograph;

public class LithographValidator : AbstractValidator<SaveLithograph.Command>
{
	public LithographValidator()
	{
        RuleFor(x => x.OrientationId)
            .GreaterThan(0)
            .WithName("Orientation")
            .WithMessage("Orientation is required.");

        RuleFor(x => x.SizeId)
            .GreaterThan(0)
            .WithName("Size")
            .WithMessage("Size is required.");
    }
}
