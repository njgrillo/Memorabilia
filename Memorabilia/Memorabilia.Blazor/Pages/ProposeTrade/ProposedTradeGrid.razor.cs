namespace Memorabilia.Blazor.Pages.ProposeTrade;

public partial class ProposedTradeGrid
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public EmailService EmailService { get; set; }

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

    private async Task Accept(ProposeTradeModel proposeTradeModel)
    {
        await UpdateStatus(proposeTradeModel, ProposeTradeStatusType.Accepted);
    }

    private async Task Cancel(ProposeTradeModel proposeTradeModel)
    {
        await UpdateStatus(proposeTradeModel, ProposeTradeStatusType.Canceled);
    }

    private void Counter(int proposeTradeId)
    {
        NavigationManager.NavigateTo($"{NavigationPath.ProposeTrade}/Review/{DataProtectorService.EncryptId(proposeTradeId)}");
    }

    private int GetProposeTradeMemorabiliaTypeId(Entity.ProposeTradeMemorabilia proposeTradeMemorabilia)
        => ApplicationStateService.CurrentUser.Id == proposeTradeMemorabilia.UserId
            ? ProposeTradeMemorabiliaType.Send.Id
            : ProposeTradeMemorabiliaType.Receive.Id;

    private string GetProposeTradeMemorabiliaTypeName(Entity.ProposeTradeMemorabilia proposeTradeMemorabilia)
        => ApplicationStateService.CurrentUser.Id == proposeTradeMemorabilia.UserId
            ? ProposeTradeMemorabiliaType.Send.Name
            : ProposeTradeMemorabiliaType.Receive.Name;

    private string GetTypeIcon(Entity.ProposeTradeMemorabilia proposeTradeMemorabilia)
        => GetProposeTradeMemorabiliaTypeId(proposeTradeMemorabilia) == ProposeTradeMemorabiliaType.Receive.Id
            ? Icons.Material.Filled.ArrowBack
            : Icons.Material.Filled.ArrowForward;

    private async Task Reject(ProposeTradeModel proposeTradeModel)
    {
        await UpdateStatus(proposeTradeModel, ProposeTradeStatusType.Rejected);
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

    private async Task UpdateStatus(ProposeTradeModel proposeTradeModel, 
                                    ProposeTradeStatusType proposeTradeStatusType)
    {
        await Mediator.Send(new UpdateProposeTradeStatus(proposeTradeModel.Id, proposeTradeStatusType));

        await Mediator.Publish(new ProposeTradeStatusChangedNotification());

        Snackbar.Add($"Trade has been {proposeTradeStatusType.Name}!", Severity.Success);

        string subject 
            = EmailSubject.ProposeTrade
                          .Replace("[[proposeTradeStatusType]]", proposeTradeStatusType.Name);

        string body
            = EmailBody.ProposeTrade
                       .Replace("[[tradePartnerName]]", proposeTradeModel.TradePartnerName)
                       .Replace("[[proposeTradeStatusType]]", proposeTradeStatusType.Name);

        EmailService.SendEmailMessage(proposeTradeModel.TradePartnerName,
                                      proposeTradeModel.TradePartnerEmail, 
                                      subject,
                                      EmailBody.ProposeTrade);
    }
}
