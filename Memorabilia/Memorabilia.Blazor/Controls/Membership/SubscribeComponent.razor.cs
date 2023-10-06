namespace Memorabilia.Blazor.Controls.Membership;

public partial class SubscribeComponent
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    protected int UserId { get; set; }

    private readonly decimal _promoterPrice
        = new(14.99);

    private readonly decimal _tier1Price
        = new(4.99);

    private readonly decimal _tier2Price
        = new(9.99);

    protected override void OnInitialized()
    {
        UserId = ApplicationStateService.CurrentUser.Id;
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
