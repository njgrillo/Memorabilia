namespace Memorabilia.Blazor.Models.PaypalClient;

public class CreateOrderRequest
{
    public ApplicationContext application_context { get; set; }

    public string intent { get; set; }

    public PaymentSource payment_source { get; set; }

    public List<PurchaseUnit> purchase_units { get; set; } = new();
}
