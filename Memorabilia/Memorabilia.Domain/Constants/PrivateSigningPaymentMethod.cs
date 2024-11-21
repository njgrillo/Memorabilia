namespace Memorabilia.Domain.Constants;

public sealed class PrivateSigningPaymentMethod : DomainItemConstant
{
    public static readonly PrivateSigningPaymentMethod Cash = new(1, "Cash");
    public static readonly PrivateSigningPaymentMethod CashApp = new(2, "Cash App");
    public static readonly PrivateSigningPaymentMethod Check = new(3, "Check");
    public static readonly PrivateSigningPaymentMethod CreditCard = new(4, "Credit Card");
    public static readonly PrivateSigningPaymentMethod MoneyOrder = new(5, "Money Order");
    public static readonly PrivateSigningPaymentMethod Paypal = new(6, "Paypal");
    public static readonly PrivateSigningPaymentMethod Venmo = new(7, "Venmo");
    public static readonly PrivateSigningPaymentMethod Zelle = new(8, "Zelle");   

    public static readonly PrivateSigningPaymentMethod[] All =
    [
        Cash,
        CashApp,
        Check,
        CreditCard,
        MoneyOrder,
        Paypal,
        Venmo,
        Zelle
    ];

    private PrivateSigningPaymentMethod(int id, string name, string abbreviation = null)
        : base(id, name, abbreviation) { }

    public static PrivateSigningPaymentMethod Find(int id)
        => All.SingleOrDefault(method => method.Id == id);

    public static PrivateSigningPaymentMethod Find(string name)
        => All.SingleOrDefault(method => method.Name == name);
}
