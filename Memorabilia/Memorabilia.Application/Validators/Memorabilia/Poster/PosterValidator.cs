namespace Memorabilia.Application.Validators.Memorabilia.Poster;

public class PosterValidator : AbstractValidator<SavePoster.Command>
{
	public PosterValidator()
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
