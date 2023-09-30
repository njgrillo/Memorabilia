namespace Memorabilia.Blazor.Models.Paypal;

public class PaypalCaptureOrderModel
{
    public PaypalCaptureOrderModel() { }

    public PaypalCaptureOrderModel(string orderId)
    {
        OrderId = orderId;
    }

    public string OrderId { get; set; }
}
