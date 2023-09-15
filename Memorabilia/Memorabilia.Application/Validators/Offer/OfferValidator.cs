namespace Memorabilia.Application.Validators.Offer;

public class OfferValidator : AbstractValidator<SaveOffer.Command>
{
    public OfferValidator()
    {
        RuleFor(x => x.Amount)
            .GreaterThan(0)
            .WithName("Amount")
            .WithMessage("Amount to Offer must be greater than 0.");
    }
}
