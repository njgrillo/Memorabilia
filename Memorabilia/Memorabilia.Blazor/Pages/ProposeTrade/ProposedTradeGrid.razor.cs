namespace Memorabilia.Blazor.Pages.ProposeTrade;

public partial class ProposedTradeGrid
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public ProposeTradeModel[] Items { get; set; }

    private async Task Accept(int proposeTradeId)
    {
        await UpdateStatus(proposeTradeId, ProposeTradeStatusType.Accepted);
    }

    private void Counter(int proposeTradeId)
    {
        NavigationManager.NavigateTo($"/Memorabilia/ProposeTrade/Counter/{DataProtectorService.EncryptId(proposeTradeId)}");
    }

    private static string GetTypeIcon(int proposeTradeMemorabiliaTypeId)
        => proposeTradeMemorabiliaTypeId == ProposeTradeMemorabiliaType.Receive.Id
            ? Icons.Material.Filled.ArrowBack
            : Icons.Material.Filled.ArrowForward;

    private async Task Reject(int proposeTradeId)
    {
        await UpdateStatus(proposeTradeId, ProposeTradeStatusType.Rejected);
    }

    private void ToggleChildContent(int proposeTradeId)
    {
        ProposeTradeModel proposeTrade
            = Items.Single(item => item.Id == proposeTradeId);

        proposeTrade.DisplayTradeDetails = !proposeTrade.DisplayTradeDetails;

        proposeTrade.ToggleIcon = proposeTrade.DisplayTradeDetails
            ? Icons.Material.Filled.ExpandLess
            : Icons.Material.Filled.ExpandMore;
    }

    private async Task UpdateStatus(int proposeTradeId, ProposeTradeStatusType status)
    {
        await CommandRouter.Send(new UpdateProposeTradeStatus(proposeTradeId, status));

        await Mediator.Publish(new ProposeTradeStatusChangedNotification());

        Snackbar.Add($"Trade has been {status.Name}!", Severity.Success);
    }
}
