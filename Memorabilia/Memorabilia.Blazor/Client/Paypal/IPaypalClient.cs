namespace Memorabilia.Blazor.Client.Paypal;

public interface IPaypalClient
{
    Task<CaptureOrderResponse> CaptureOrder(string orderId);

    Task<CreateOrderResponse> CreateOrder(PaypalOrderModel order);
}
