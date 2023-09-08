namespace Memorabilia.Blazor.Pages.ProposeTrade;

public partial class ViewProposedTrades
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public ICourier Courier { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    protected ProposeTradesModel Model { get; set; }
        = new();

    protected override async Task OnInitializedAsync()
    {
        await Load();

        Courier.Subscribe<ProposeTradeStatusChangedNotification>(OnProposeTradeStatusChanged);
    }

    private async Task Load()
    {
        Entity.ProposeTrade[] proposeTrades
            = await QueryRouter.Send(new GetProposedTrades());

        Model = new(proposeTrades, ApplicationStateService.CurrentUser.Id);
    }

    private async Task OnProposeTradeStatusChanged(ProposeTradeStatusChangedNotification notification)
    {
        await Load();

        StateHasChanged();
    }
}
