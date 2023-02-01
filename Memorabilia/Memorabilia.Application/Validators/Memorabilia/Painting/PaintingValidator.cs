namespace Memorabilia.Application.Validators.Memorabilia.Painting;

public class PaintingValidator : AbstractValidator<SavePainting.Command>
{
	public PaintingValidator()
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
