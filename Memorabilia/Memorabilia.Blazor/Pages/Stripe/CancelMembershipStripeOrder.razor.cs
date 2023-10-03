namespace Memorabilia.Blazor.Pages.Stripe;

public partial class CancelMembershipStripeOrder
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

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
            = await QueryRouter.Send(new GetStripePaymentTransaction(OrderId));

        EditModel = new(transaction)
        {
            StripePaymentStatusType = StripePaymentStatusType.Canceled
        };

        await CommandRouter.Send(new SaveStripePaymentTransaction.Command(EditModel));
    }
}
