namespace Memorabilia.Application.Validators.PrivateSigning;

public class PrivateSigningPaymentOptionValidator : AbstractValidator<PrivateSigningPaymentOptionEditModel>
{
    public PrivateSigningPaymentOptionValidator()
    {
        RuleFor(x => x.PrivateSigningId)
            .GreaterThan(0)
            .WithName("PrivateSigning")
            .WithMessage("Private Signing is required.");

        RuleFor(x => x.PrivateSigningPaymentMethodId)
            .GreaterThan(0)
            .WithName("PrivateSigningPaymentMethod")
            .WithMessage("Payment Method is required.");

    }
}
