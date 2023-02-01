namespace Memorabilia.Application.Validators.Memorabilia.IndexCard;

public class IndexCardValidator : AbstractValidator<SaveIndexCard.Command>
{
	public IndexCardValidator()
	{
        RuleFor(x => x.SizeId)
            .GreaterThan(0)
            .WithName("Size")
            .WithMessage("Size is required.");
    }
}
