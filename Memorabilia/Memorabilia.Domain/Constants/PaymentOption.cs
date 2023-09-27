namespace Memorabilia.Domain.Constants;

public sealed class PaymentOption : DomainItemConstant
{
    public static readonly PaymentOption PayPal = new(1, "PayPal");
    public static readonly PaymentOption Venmo = new(2, "Venmo");
    public static readonly PaymentOption CashApp = new(3, "Cash App", "CA");
    public static readonly PaymentOption Zelle = new(4, "Zelle");

    public static readonly PaymentOption[] All =
    {
        PayPal,
        Venmo,
        CashApp, 
        Zelle
    };

    private PaymentOption(int id, string name, string abbreviation = null)
        : base(id, name, abbreviation) { }

    public static PaymentOption Find(int id)
        => All.SingleOrDefault(paymentOption => paymentOption.Id == id);
}
