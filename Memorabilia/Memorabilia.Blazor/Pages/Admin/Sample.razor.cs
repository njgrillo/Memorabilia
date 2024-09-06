using Memorabilia.Blazor.Pages.DisplayCase;

namespace Memorabilia.Blazor.Pages.Admin;

public partial class Sample
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

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

    public List<DropItem> People { get; set; }
        = [];

    protected AddressEditModel SelectedAddress { get; set; }
        = new();    

    protected async Task CreatePaypalOrder()
    {
        var reference = Guid.NewGuid().ToString();

        PaypalOrderModel order = new("19.99", reference)
        {
            Buyer = new PaypalUserModel
            {
                EmailAddress = "sb-e43av327634072@personal.example.com",
                FirstName = "Mike",
                LastName = "GraphinAllDayTestBuyer",
            },

            Seller = new PaypalUserModel
            {
                EmailAddress = "sb-ul3dv27633929@personal.example.com",
                FirstName = "Joe",
                LastName = "GraphinAllDayTestSeller",
            }
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

    #region Mt.Rushmore
    private void AddMtRushmorePerson()
    {
        if (AvailableMtRushmorePeople.Any(item => item.PersonId == SelectedMtRushmorePerson.Id))
            return;

        AvailableMtRushmorePeople.Add(new DropItem { Identifier = "1", ImageFileName = SelectedMtRushmorePerson.ImageFileName, PersonId = SelectedMtRushmorePerson.Id });

        RefreshMtRushmoreContainer();

        SelectedMtRushmorePerson = new();
    }

    private void MtRushmoreItemUpdated(MudItemDropInfo<DropItem> dropItem)
    {
        dropItem.Item.Identifier = dropItem.DropzoneIdentifier;
    }

    private void RefreshMtRushmoreContainer()
    {
        StateHasChanged();

        _mtRushmoreContainer.Refresh();
    }

    private readonly List<DropItem> AvailableMtRushmorePeople
        = [];

    private MudDropContainer<DropItem> _mtRushmoreContainer;

    public Entity.Person SelectedMtRushmorePerson { get; set; }
        = new();
    #endregion

    #region "Display"
    private List<DropItem> AvailableDisplayPeople
        = [];

    private int DisplayColumns 
        = 0;

    private MudDropContainer<DropItem> _displayContainer;

    public Entity.Person SelectedDisplayPerson { get; set; }
        = new();

    private void AddDisplayPerson()
    {
        if (AvailableDisplayPeople.Any(item => item.PersonId == SelectedDisplayPerson.Id))
            return;

        AvailableDisplayPeople.Add(new DropItem { Identifier = "selectPeople", ImageFileName = SelectedDisplayPerson.ImageFileName, PersonId = SelectedMtRushmorePerson.Id });

        RefreshDisplayContainer();

        SelectedDisplayPerson = new();
    }

    protected async Task AddMemorabilia()
    {
        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.ExtraLarge,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<AddDisplayCaseMemorabiliaDialog>(string.Empty,
                                                                         [],
                                                                         options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var items = (List<MemorabiliaModel>)result.Data;

        var results
            = items.Select(item => new DropItem
                   {
                       Identifier = "selectPeople",
                       ImageFileName = item.ImageFileName
                   })
                   .ToList();

        AvailableDisplayPeople.AddRange(results);

        RefreshDisplayContainer();
    }

    private void DisplayItemUpdated(MudItemDropInfo<DropItem> dropItem)
    {
        dropItem.Item.Identifier = dropItem.DropzoneIdentifier;
    }

    private void RefreshDisplayContainer()
    {
        StateHasChanged();

        _displayContainer.Refresh();
    }
    #endregion 



    public class DropItem
    {        
        public string Identifier { get; set; }

        public string ImageFileName { get; set; }

        public int PersonId { get; set; }
    }
}
