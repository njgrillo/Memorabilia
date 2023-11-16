namespace Memorabilia.Blazor.Services;

public class PaypalService(IPaypalClient paypalClient)
{
    public async Task<CaptureOrderResponse> Capture(PaypalCaptureOrderModel captureOrder)
        => await paypalClient.CaptureOrder(captureOrder.OrderId);

    public async Task<CreateOrderResponse> Order(PaypalOrderModel order)
        => await paypalClient.CreateOrder(order);
}
