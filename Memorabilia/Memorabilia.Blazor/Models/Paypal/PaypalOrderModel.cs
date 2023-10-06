namespace Memorabilia.Blazor.Models.Paypal;

public class PaypalOrderModel
{
    public PaypalOrderModel() { }

    public PaypalOrderModel(string price, 
                            string reference)
    {
        Price = price;
        Reference = reference;
    }

    public PaypalUserModel Buyer { get; set; }

    public string Currency { get; set; }
        = "USD";

    public string Price { get; set; }

    public string Reference { get; set; }

    public PaypalUserModel Seller { get; set; }
}
