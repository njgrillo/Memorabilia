namespace Memorabilia.Application.Validators.Memorabilia.Photo;

public class PhotoValidator : AbstractValidator<SavePhoto.Command>
{
	public PhotoValidator()
	{
        RuleFor(x => x.BrandId)
            .GreaterThan(0)
            .WithName("Brand")
            .WithMessage("Brand is required.");

        RuleFor(x => x.OrientationId)
            .GreaterThan(0)
            .WithName("Orientation")
            .WithMessage("Orientation is required.");

        RuleFor(x => x.SizeId)
            .GreaterThan(0)
            .WithName("Size")
            .WithMessage("Size is required.");

        RuleFor(x => x.PhotoTypeId)
            .GreaterThan(0)
            .NotNull()
            .WithName("Type")
            .WithMessage("Type is required.");
    }
}
