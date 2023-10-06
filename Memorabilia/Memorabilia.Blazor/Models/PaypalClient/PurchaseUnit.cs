namespace Memorabilia.Blazor.Models.PaypalClient;

public class PurchaseUnit
{
    public Amount amount { get; set; }

    public Payee payee { get; set; }

    public PaymentInstruction payment_instruction { get; set; }

    public Payments payments { get; set; }

    public string reference_id { get; set; }

    public Shipping shipping { get; set; }    
}
