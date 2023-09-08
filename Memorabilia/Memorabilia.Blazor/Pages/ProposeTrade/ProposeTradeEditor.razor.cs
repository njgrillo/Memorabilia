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
    public IMediator Mediator { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public ProposeTradeValidator Validator { get; set; }

    [Parameter]
    public string EncryptMemorabiliaId { get; set; }

    protected ProposeTradeEditModel EditModel
        = new();

    protected int MemorabiliaId;

    protected Alert[] ValidationResultAlerts
        => EditModel.ValidationResult.Errors?.Any() ?? false
            ? EditModel.ValidationResult.Errors.Select(error => new Alert(error.ErrorMessage, Severity.Error)).ToArray()
            : Array.Empty<Alert>();

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);        

        Entity.Memorabilia receiveMemorabilia
            = await Mediator.Send(new GetProposeTradeMemorabiliaItem(MemorabiliaId));

        EditModel.ReceiveItems.Add(new ProposeTradeMemorabiliaEditModel(receiveMemorabilia,
                                                                        ProposeTradeMemorabiliaType.Receive));

        EditModel.ReceiverUser ??= ApplicationStateService.CurrentUser;

        if (EditModel.SenderUser == null)
        {
            Entity.User senderUser
                        = await Mediator.Send(new GetUserById(receiveMemorabilia.UserId));

            EditModel.SenderUser = senderUser;
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
            ["UserId"] = EditModel.SenderUser.Id
        };

        var dialog = DialogService.Show<AddProposeTradeReceiveMemorabiliaDialog>(string.Empty,
                                                                                 parameters,
                                                                                 options);

        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var items = (List<SiteMemorabiliaModel>)result.Data;

        List<ProposeTradeMemorabiliaEditModel> memorabilias
            = items.Select(item => new ProposeTradeMemorabiliaEditModel(item.Memorabilia,
                                                                        ProposeTradeMemorabiliaType.Receive))
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
            = items.Select(item => new ProposeTradeMemorabiliaEditModel(item.Memorabilia,
                                                                        ProposeTradeMemorabiliaType.Send))
                   .ToList();

        EditModel.SendItems.AddRange(memorabilias);

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
    }
}
