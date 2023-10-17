namespace Memorabilia.Blazor.Pages.Offer;

public partial class ViewOffers
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public ICourier Courier { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    protected OffersModel Model { get; set; }
        = new();

    protected override async Task OnInitializedAsync()
    {
        await Load();

        Courier.Subscribe<OfferStatusChangedNotification>(OnOfferStatusChanged);
    }

    private async Task Load()
    {
        Entity.Offer[] offers
            = await Mediator.Send(new GetOffers());

        Model = new(offers, ApplicationStateService.CurrentUser.Id);
    }

    private async Task OnOfferStatusChanged(OfferStatusChangedNotification notification)
    {
        await Load();

        StateHasChanged();
    }
}
