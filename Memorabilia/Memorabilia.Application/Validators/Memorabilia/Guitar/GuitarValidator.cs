namespace Memorabilia.Application.Validators.Memorabilia.Guitar;

public class GuitarValidator : AbstractValidator<SaveGuitar.Command>
{
	public GuitarValidator()
	{
        RuleFor(x => x.BrandId)
            .GreaterThan(0)
            .WithName("Brand")
            .WithMessage("Brand is required.");

        RuleFor(x => x.SizeId)
            .GreaterThan(0)
            .WithName("Size")
            .WithMessage("Size is required.");
    }
}
