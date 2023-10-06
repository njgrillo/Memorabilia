namespace Memorabilia.Domain.Constants;

public sealed class StripeRecurringPaymentInterval : DomainItemConstant
{
    public static readonly StripeRecurringPaymentInterval Day = new(1, "day");
    public static readonly StripeRecurringPaymentInterval Month = new(2, "month");
    public static readonly StripeRecurringPaymentInterval Week = new(3, "week");
    public static readonly StripeRecurringPaymentInterval Year = new(4, "year");

    public static readonly StripeRecurringPaymentInterval[] All =
    {
        Day,
        Month,
        Week, 
        Year  
    };

    private StripeRecurringPaymentInterval(int id, string name, string abbreviation = null)
        : base(id, name, abbreviation) { }
}
