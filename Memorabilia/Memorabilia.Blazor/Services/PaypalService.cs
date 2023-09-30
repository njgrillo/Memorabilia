namespace Memorabilia.Blazor.Services;

public class PaypalService
{
    private readonly IPaypalClient _paypalClient;

	public PaypalService(IPaypalClient paypalClient)
	{
        _paypalClient = paypalClient;
    }

    public async Task<CaptureOrderResponse> Capture(PaypalCaptureOrderModel captureOrder)
    {
        CaptureOrderResponse response 
            = await _paypalClient.CaptureOrder(captureOrder.OrderId);

        return response;
    }

    public async Task<CreateOrderResponse> Order(PaypalOrderModel order)
    {
        CreateOrderResponse response 
            = await _paypalClient.CreateOrder(order);

        return response;
    }
}
