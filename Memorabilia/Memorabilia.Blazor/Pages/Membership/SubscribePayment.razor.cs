namespace Memorabilia.Blazor.Pages.Membership;

public partial class SubscribePayment
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

    [Parameter]
    public string EncryptRoleId { get; set; }

    [Parameter]
    public string EncryptUserId { get; set; }

    protected bool IsAutoRenew { get; set; }
        = true;

    protected int RoleId { get; set; }

    protected int UserId { get; set; }

    private readonly decimal _promoterPrice
        = new(14.99);

    private readonly decimal _tier1Price
        = new(4.99);

    private readonly decimal _tier2Price
        = new(9.99);

    protected override void OnInitialized()
    {
        RoleId = DataProtectorService.DecryptId(EncryptRoleId);
        UserId = DataProtectorService.DecryptId(EncryptUserId);
    }

    protected decimal Price
        => RoleId switch
                  {
                      (int) Enum.Role.Promoter => _promoterPrice,
                      (int) Enum.Role.SubscriberTier1 => _tier1Price,
                      (int) Enum.Role.SubscriberTier2 => _tier2Price,                
                      _ => throw new NotImplementedException()
                  };

    private PaymentModel GeneratePaymentModel()
    {
        int amount = (int)(Price * 100);

        var lineItems = new List<LineItemModel>();
        var lineItem = new LineItemModel(amount, 1);

        string itemDescription = IsAutoRenew
            ? "Auto renews every month"
            : "Access for one month";

        string name = "Graphinallday";

        ProductModel product = new(itemDescription, name);

        lineItem.SetProduct(product);

        if (IsAutoRenew)
        {
            lineItem.Recurring
                = new RecurringModel(StripeRecurringPaymentInterval.Month.Name, 1);
        }        

        lineItems.Add(lineItem);

        string orderId = Guid.NewGuid().ToString();
        string encryptedOrderId = DataProtectorService.Encrypt(orderId);

        string successUrl = $"{SiteSettings.Url}{NavigationPath.StripeConfirmMembership}?roleId={DataProtectorService.EncryptId(RoleId)}&orderId={encryptedOrderId}&userId={DataProtectorService.EncryptId(UserId)}";
        string cancelUrl = $"{SiteSettings.Url}{NavigationPath.StripeCancelMembership}?orderId={encryptedOrderId}&userId={DataProtectorService.EncryptId(UserId)}";

        var paymentModel 
            = new PaymentModel(UserId,
                               orderId,
                               lineItems,
                               successUrl,
                               cancelUrl,
                               IsAutoRenew ? StripePaymentMode.Subscription.Name : StripePaymentMode.Payment.Name);

        CustomerModel customerModel 
            = new(ApplicationStateService.CurrentUser.EmailAddress,
                  ApplicationStateService.CurrentUser.StripeCustomerId,
                  $"{ApplicationStateService.CurrentUser.FirstName} {ApplicationStateService.CurrentUser.LastName}");

        paymentModel.Customer = customerModel;

        return paymentModel;
    }

    private void PaypalCheckout()
    {
        //TODO: Finish implementation
    }

    private async Task StripeCheckout()
    {
        PaymentModel paymentModel = GeneratePaymentModel();

        Session session
            = await StripeService.CreatePaymentAsync(paymentModel);

        NavigationManager.NavigateTo($"{session.Url}");
    }
}
