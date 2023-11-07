namespace Memorabilia.Blazor.Pages.Admin;

public partial class Sample
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public PaypalService PaypalService { get; set; }

    [Inject]
    public ISiteSettings SiteSettings { get; set; }

    [Inject]
    public StripeService StripeService { get; set; }    

    protected string PaypalRedirectUrl { get; set; }

    protected string Address { get; set; }

    protected Models.Addresses.Address SelectedAddress { get; set; }
        = new();

    protected async Task CreatePaypalOrder()
    {
        var reference = Guid.NewGuid().ToString();

        PaypalOrderModel order = new("19.99", reference);

        order.Buyer = new PaypalUserModel
        {
            EmailAddress = "sb-e43av327634072@personal.example.com",
            FirstName = "Mike",
            LastName = "GraphinAllDayTestBuyer",
        };

        order.Seller = new PaypalUserModel
        {
            EmailAddress = "sb-ul3dv27633929@personal.example.com",
            FirstName = "Joe",
            LastName = "GraphinAllDayTestSeller",
        };

        CreateOrderResponse response = await PaypalService.Order(order);               

        PaypalRedirectUrl = response.links[1].href;

        NavigationManager.NavigateTo(PaypalRedirectUrl);
    }

    protected async Task CreateStripeOrder()
    {
        int amount = 1499;
        int quantity = 1;

        var lineItems = new List<LineItemModel>();
        var lineItem = new LineItemModel(amount, quantity);

        string itemDescription = "Graphinallday subscription purchase";
        string name = "Graphinallday Subscription";

        ProductModel product = new(itemDescription, name);

        lineItem.SetProduct(product);        
        lineItems.Add(lineItem);

        string orderId = Guid.NewGuid().ToString();
        string encryptedOrderId = DataProtectorService.Encrypt(orderId);

        string successUrl = $"{SiteSettings.Url}{NavigationPath.StripeConfirm}?orderId={encryptedOrderId}";
        string cancelUrl = $"{SiteSettings.Url}{NavigationPath.StripeCancel}?orderId={encryptedOrderId}";

        var paymentModel 
            = new PaymentModel(ApplicationStateService.CurrentUser.Id, 
                               orderId,
                               lineItems, 
                               successUrl, 
                               cancelUrl);

        Session session 
            = await StripeService.CreatePaymentAsync(paymentModel);

        NavigationManager.NavigateTo(session.Url);
    }
}
