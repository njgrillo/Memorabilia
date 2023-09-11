namespace Memorabilia.Blazor.Pages.ProposeTrade;

public partial class ProposeTradeEditor
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public EmailService EmailService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public ProposeTradeValidator Validator { get; set; }

    [Parameter]
    public string EncryptMemorabiliaId { get; set; }

    [Parameter]
    public string EncryptProposeTradeId { get; set; }    

    protected ProposeTradeEditModel EditModel
        = new();

    protected bool IsReadOnly
        => IsReviewMode &&
           EditModel.ProposeTradeStatusTypeId == ProposeTradeStatusType.Pending.Id &&
           ApplicationStateService.CurrentUser.Id == (EditModel.ProposeTradeCreateUser?.Id ?? 0);

    protected bool IsReviewMode
        => !EncryptProposeTradeId.IsNullOrEmpty();

    protected int? MemorabiliaId;

    protected int? ProposeTradeId;

    protected Alert[] ValidationResultAlerts
        => EditModel.ValidationResult.Errors?.Any() ?? false
            ? EditModel.ValidationResult.Errors.Select(error => new Alert(error.ErrorMessage, Severity.Error)).ToArray()
            : Array.Empty<Alert>();

    protected override async Task OnInitializedAsync()
    {
        if (!IsReviewMode)
        {
            MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);

            Entity.Memorabilia receiveMemorabilia
                = await Mediator.Send(new GetProposeTradeMemorabiliaItem(MemorabiliaId.Value));

            Entity.User senderUser
                = await Mediator.Send(new GetUserById(receiveMemorabilia.UserId));

            EditModel = new(ApplicationStateService.CurrentUser, senderUser, receiveMemorabilia);
        }
        else
        {
            ProposeTradeId = DataProtectorService.DecryptId(EncryptProposeTradeId);

            Entity.ProposeTrade proposeTrade
                = await Mediator.Send(new GetPropopseTrade(ProposeTradeId.Value));

            EditModel = new(ApplicationStateService.CurrentUser.Id, proposeTrade);
        }        
    }

    protected async Task AddReceiveMemorabilia()
    {
        var options = new DialogOptions
        {
            MaxWidth = MaxWidth.ExtraLarge,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var parameters = new DialogParameters
        {
            ["UserId"] = EditModel.TradePartnerUserId
        };

        var dialog = DialogService.Show<AddProposeTradeReceiveMemorabiliaDialog>(string.Empty,
                                                                                 parameters,
                                                                                 options);

        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var items = (List<SiteMemorabiliaModel>)result.Data;

        List<ProposeTradeMemorabiliaEditModel> memorabilias
            = items.Select(item => new ProposeTradeMemorabiliaEditModel(item.Memorabilia))
                   .ToList();

        EditModel.ReceiveItems.AddRange(memorabilias);
    }

    protected async Task AddSendMemorabilia()
    {
        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.ExtraLarge,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<AddProposeTradeSendMemorabiliaDialog>(string.Empty,
                                                                              new DialogParameters(),
                                                                              options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var items = (List<MemorabiliaModel>)result.Data;

        List<ProposeTradeMemorabiliaEditModel> memorabilias
            = items.Select(item => new ProposeTradeMemorabiliaEditModel(item.Memorabilia))
                   .ToList();

        EditModel.SendItems.AddRange(memorabilias);

    }    

    protected async Task OnAccept()
    {
        await UpdateTradeStatus(ProposeTradeStatusType.Accepted);
    }

    protected async Task OnCancel()
    {
        await UpdateTradeStatus(ProposeTradeStatusType.Canceled);
    }

    protected async Task OnCounter()
    {
        await CommandRouter.Send(new UpdateProposeTradeStatus(EditModel.Id,
                                                              ProposeTradeStatusType.Countered));

        EditModel.Id = 0;
        EditModel.SwitchCreatorAndPartner(ApplicationStateService.CurrentUser.Id);

        await OnSend();
    }

    protected async Task OnReject()
    {
        await UpdateTradeStatus(ProposeTradeStatusType.Rejected);
    }

    protected async Task OnSend()
    {
        var command = new AddProposeTrade.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        Snackbar.Add("Trade proposal sent!", Severity.Success);

        NavigationManager.NavigateTo(NavigationPath.ProposedTrades);

        string body
            = EmailBody.ProposeTradeSent
                       .Replace("[[userName]]", EditModel.UserName);

        EmailService.SendEmailMessage(EditModel.TradePartnerName,
                                      EditModel.TradePartnerEmail,
                                      EmailSubject.ProposeTradeSent,
                                      body);
    }

    private async Task UpdateTradeStatus(ProposeTradeStatusType proposeTradeStatusType)
    {
        await CommandRouter.Send(new UpdateProposeTradeStatus(EditModel.Id,
                                                              proposeTradeStatusType));

        string subject
            = EmailSubject.ProposeTrade
                          .Replace("[[proposeTradeStatusType]]", proposeTradeStatusType.Name);

        string body
            = EmailBody.ProposeTrade
                       .Replace("[[tradePartnerName]]", EditModel.TradePartnerName)
                       .Replace("[[proposeTradeStatusType]]", proposeTradeStatusType.Name);

        EmailService.SendEmailMessage(EditModel.TradePartnerName,
                                      EditModel.TradePartnerEmail,
                                      subject,
                                      body);

        Snackbar.Add($"Trade proposal has been {proposeTradeStatusType.Name}!", Severity.Success);

        string navigationPath
            = proposeTradeStatusType == ProposeTradeStatusType.Accepted
                ? NavigationPath.Home
                : NavigationPath.ProposedTrades;

        NavigationManager.NavigateTo(navigationPath);
    }
}
