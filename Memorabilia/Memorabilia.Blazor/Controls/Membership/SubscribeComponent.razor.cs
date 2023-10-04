namespace Memorabilia.Blazor.Controls.Membership;

public partial class SubscribeComponent
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISiteSettings SiteSettings { get; set; }

    [Inject]
    public StripeService StripeService { get; set; }

    protected int UserId { get; set; }

    private decimal _promoterPrice
        = new(14.99);

    private decimal _tier1Price
        = new(4.99);

    private decimal _tier2Price
        = new(9.99);

    protected override void OnInitialized()
    {
        UserId = ApplicationStateService.CurrentUser.Id;
    }

    protected async Task OnPromoterSelect()
    {
        await Charge(_promoterPrice, Role.Promoter);
    }

    protected async Task OnTier1Select()
    {
        await Charge(_tier1Price, Role.SubscriberTier1);
    }

    protected async Task OnTier2Select()
    {
        await Charge(_tier2Price, Role.SubscriberTier2);
    }

    private async Task Charge(decimal price, Role role)
    {
        int amount = (int)(price * 100);

        var lineItems = new List<LineItemModel>();
        var lineItem = new LineItemModel(amount, 1);

        string itemDescription = "Graphinallday subscription purchase";
        string name = "Graphinallday Subscription";

        ProductModel product = new(itemDescription, name);

        lineItem.SetProduct(product);
        lineItems.Add(lineItem);

        string orderId = Guid.NewGuid().ToString();
        string encryptedOrderId = DataProtectorService.Encrypt(orderId);

        string successUrl = $"{SiteSettings.Url}{NavigationPath.StripeConfirmMembership}?roleId={DataProtectorService.EncryptId(role.Id)}&orderId={encryptedOrderId}&userId={DataProtectorService.EncryptId(UserId)}";
        string cancelUrl = $"{SiteSettings.Url}{NavigationPath.StripeCancelMembership}?orderId={encryptedOrderId}&userId={DataProtectorService.EncryptId(UserId)}";

        var paymentModel
            = new PaymentModel(UserId,
                               orderId,
                               lineItems,
                               successUrl,
                               cancelUrl);

        Session session
            = await StripeService.CreatePaymentAsync(paymentModel);

        NavigationManager.NavigateTo($"{session.Url}");
    }
}
