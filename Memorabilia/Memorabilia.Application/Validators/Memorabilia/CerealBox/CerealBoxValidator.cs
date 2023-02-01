namespace Memorabilia.Application.Validators.Memorabilia.CerealBox;

public class CerealBoxValidator : AbstractValidator<SaveCerealBox.Command>
{
	public CerealBoxValidator()
	{
        RuleFor(x => x.BrandId)
            .GreaterThan(0)
            .WithName("Brand")
            .WithMessage("Brand is required.");
    }
}
