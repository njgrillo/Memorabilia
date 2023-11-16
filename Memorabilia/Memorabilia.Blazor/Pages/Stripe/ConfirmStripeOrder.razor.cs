using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Blazor.Pages.Stripe;

public partial class ConfirmStripeOrder
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Parameter]
    public string EncryptOrderId { get; set; }

    protected string OrderId { get; set; }

    protected StripePaymentTransactionEditModel EditModel { get; set; }
        = new();

    protected override async Task OnInitializedAsync()
    {
        OrderId = DataProtectorService.Decrypt(EncryptOrderId);

        Entity.StripePaymentTransaction transaction 
            = await Mediator.Send(new GetStripePaymentTransaction(OrderId));

        EditModel = new(transaction)
        {
            StripePaymentStatusType = StripePaymentStatusType.Completed
        };

        await Mediator.Send(new SaveStripePaymentTransaction.Command(EditModel));
    }
}
