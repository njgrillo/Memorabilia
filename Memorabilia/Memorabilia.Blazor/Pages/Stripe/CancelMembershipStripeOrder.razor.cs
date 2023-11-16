using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Blazor.Pages.Stripe;

public partial class CancelMembershipStripeOrder
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Parameter]
    public string EncryptOrderId { get; set; }

    [Parameter]
    public string EncryptUserId { get; set; }

    protected StripePaymentTransactionEditModel EditModel { get; set; }
        = new();

    protected string OrderId { get; set; }

    protected int UserId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        OrderId = DataProtectorService.Decrypt(EncryptOrderId);
        UserId = DataProtectorService.DecryptId(EncryptUserId);

        Entity.StripePaymentTransaction transaction
            = await Mediator.Send(new GetStripePaymentTransaction(OrderId));

        EditModel = new(transaction)
        {
            StripePaymentStatusType = StripePaymentStatusType.Canceled
        };

        await Mediator.Send(new SaveStripePaymentTransaction.Command(EditModel));
    }
}
