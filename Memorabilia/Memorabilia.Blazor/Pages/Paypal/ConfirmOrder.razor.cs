namespace Memorabilia.Blazor.Pages.Paypal;

public partial class ConfirmOrder
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public PaypalService PaypalService { get; set; }

    [Parameter]
    public string EncryptOrderId { get; set; }

    protected string OrderId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        OrderId = DataProtectorService.Decrypt(EncryptOrderId);

        PaypalCaptureOrderModel capture = new(OrderId);

        await PaypalService.Capture(capture);
    }
}
