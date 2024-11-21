namespace Memorabilia.Application.Validators.PrivateSigning.Promoter.PaymentOptions;

public class PromoterPaymentOptionsValidator : AbstractValidator<SavePromoterPaymentOptions.Command>
{
    public PromoterPaymentOptionsValidator()
    {
        RuleForEach(x => x.PaymentOptions)
            .SetValidator(new PromoterPaymentOptionValidator());
    }
}
