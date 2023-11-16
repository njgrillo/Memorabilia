using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Blazor.Pages.Paypal;

public partial class CancelOrder
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Parameter]
    public string EncryptOrderId { get; set; }

    protected string OrderId { get; set; }

    protected override void OnInitialized()
    {
        OrderId = DataProtectorService.Decrypt(EncryptOrderId);
    }
}
