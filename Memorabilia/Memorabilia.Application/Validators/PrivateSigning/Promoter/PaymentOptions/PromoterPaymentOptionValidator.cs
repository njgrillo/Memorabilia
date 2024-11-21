namespace Memorabilia.Application.Validators.PrivateSigning.Promoter.PaymentOptions;

public class PromoterPaymentOptionValidator : AbstractValidator<PromoterPaymentOptionEditModel>
{
    public PromoterPaymentOptionValidator()
    {
        RuleFor(x => x.PrivateSigningPaymentMethodId)
            .GreaterThan(0)
            .WithName("PrivateSigningPaymentMethodId")
            .WithMessage("Payment Method Id is required.");

        RuleFor(x => x.PaymentMethodHandle)
            .MaximumLength(100)
            .WithName("Handle")
            .WithMessage("Handle must be 100 characters or less.");
    }
}
