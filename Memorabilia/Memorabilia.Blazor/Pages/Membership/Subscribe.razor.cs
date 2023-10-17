namespace Memorabilia.Blazor.Pages.Membership;

public partial class Subscribe
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string EncryptUserId { get; set; }

    protected bool IsUpgrade
        => NavigationManager.Uri.Contains("Upgrade", StringComparison.OrdinalIgnoreCase);

    protected int UserId { get; set; }

    private int _featureWidth
        = 23;

    private readonly decimal _promoterPrice
        = new(14.99);

    private readonly decimal _tier1Price
        = new(4.99);

    private readonly decimal _tier2Price
        = new(9.99);

    protected override void OnInitialized()
    {
        _featureWidth = IsUpgrade
            ? 32
            : 23;            
    }

    protected override void OnParametersSet()
    {
        if (IsUpgrade)
        {
            UserId = ApplicationStateService.CurrentUser.Id;
            return;
        }

        if (EncryptUserId.IsNullOrEmpty())
            return;

        UserId = DataProtectorService.DecryptId(EncryptUserId);
    }

    protected void OnFreeSelect()
    {
        NavigationManager.NavigateTo(NavigationPath.Registered);
    }

    protected void OnPromoterSelect()
    {
        Checkout(Role.Promoter);
    }

    protected void OnTier1Select()
    {
        Checkout(Role.SubscriberTier1);
    }

    protected void OnTier2Select()
    {
        Checkout(Role.SubscriberTier2);
    }

    private void Checkout(Role role)
    {
        NavigationManager.NavigateTo($"{NavigationPath.SubscriptionPayment}/{DataProtectorService.EncryptId(role.Id)}/{DataProtectorService.EncryptId(UserId)}");
    }    
}
