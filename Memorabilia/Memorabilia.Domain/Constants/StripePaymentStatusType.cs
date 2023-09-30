namespace Memorabilia.Domain.Constants;

public sealed class StripePaymentStatusType : DomainItemConstant
{
    public static readonly StripePaymentStatusType Canceled = new(1, "Canceled");
    public static readonly StripePaymentStatusType Completed = new(2, "Completed");
    public static readonly StripePaymentStatusType Pending = new(3, "Pending");

    public static readonly StripePaymentStatusType[] All =
    {
        Canceled,
        Completed,
        Pending
    };

    private StripePaymentStatusType(int id, string name)
        : base(id, name) { }

    public static StripePaymentStatusType Find(int id)
        => All.SingleOrDefault(stripePaymentStatusType => stripePaymentStatusType.Id == id);
}
