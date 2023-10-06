namespace Memorabilia.Domain.Constants;

public sealed class StripePaymentMode : DomainItemConstant
{
    public static readonly StripePaymentMode Payment = new(1, "payment");
    public static readonly StripePaymentMode Subscription = new(2, "subscription");

    public static readonly StripePaymentMode[] All =
    {
        Payment,
        Subscription
    };

    private StripePaymentMode(int id, string name, string abbreviation = null)
        : base(id, name, abbreviation) { }
}
