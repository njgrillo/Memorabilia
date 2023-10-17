namespace Memorabilia.Blazor.Pages.Transaction;

public partial class TransactionEditor
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public MemorabiliaTransactionValidator Validator { get; set; }

    [Parameter]
    public string EncryptId { get; set; }

    protected MemorabiliaTransactionEditModel EditModel
        = new();

    protected int Id;

    protected bool IsDetailView
        = true;

    protected bool Loaded;    

    protected List<MemorabiliaModel> SelectedMemorabilia
        = new();

    protected Alert[] ValidationResultAlerts
        => EditModel.ValidationResult.Errors?.Any() ?? false
            ? EditModel.ValidationResult.Errors.Select(error => new Alert(error.ErrorMessage, Severity.Error)).ToArray()
            : Array.Empty<Alert>();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (EditModel.ValidationResult.IsValid)
            return;

        await JSRuntime.ScrollToAlert();
    }

    protected override async Task OnInitializedAsync()
    {
        Id = DataProtectorService.DecryptId(EncryptId);

        if (Id == 0)
        {
            EditModel = new MemorabiliaTransactionEditModel
            {
                UserId = ApplicationStateService.CurrentUser.Id
            };

            Loaded = true;

            return;
        }

        await Load();

        Loaded = true;
    }

    protected async Task AddPartialTradeMemorabilia()
    {
        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.ExtraLarge,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<AddPartialTradeMemorabiliaDialog>(string.Empty,
                                                                          new DialogParameters(),
                                                                          options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var items = (List<MemorabiliaModel>)result.Data;

        List<MemorabiliaTransactionTradeEditModel> trades
            = items.Select(item => new MemorabiliaTransactionTradeEditModel
            {
                Memorabilia = item.Memorabilia,
                MemorabiliaId = item.Id,
                MemorabiliaTransactionId = EditModel.Id,
                TransactionType = TransactionType.PartialTrade
            }).ToList();

        EditModel.Trades.AddRange(trades);
    }

    protected async Task AddSaleMemorabilia()
    {
        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.ExtraLarge,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<AddSaleMemorabiliaDialog>(string.Empty,
                                                                  new DialogParameters(),
                                                                  options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var items = (List<MemorabiliaModel>)result.Data;

        List<MemorabiliaTransactionSaleEditModel> sales
            = items.Select(item => new MemorabiliaTransactionSaleEditModel
            {
                Memorabilia = item.Memorabilia,
                MemorabiliaId = item.Id,
                MemorabiliaTransactionId = EditModel.Id
            }).ToList();

        EditModel.Sales.AddRange(sales);
    }

    protected async Task AddTradeMemorabilia()
    {
        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.ExtraLarge,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<AddTradeMemorabiliaDialog>(string.Empty,
                                                                   new DialogParameters(),
                                                                   options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var items = (List<MemorabiliaModel>)result.Data;

        List<MemorabiliaTransactionTradeEditModel> trades
            = items.Select(item => new MemorabiliaTransactionTradeEditModel
            {
                Memorabilia = item.Memorabilia,
                MemorabiliaId = item.Id,
                MemorabiliaTransactionId = EditModel.Id,
                TransactionType = TransactionType.Trade
            }).ToList();

        EditModel.Trades.AddRange(trades);
    }

    private async Task Load()
    {
        EditModel = await Mediator.Send(new GetMemorabiliaTransaction(Id));
    }

    protected async Task OnSave()
    {
        await Save();
        await Load();
    }

    protected async Task OnSaveClose()
    {
        await Save();

        NavigationManager.NavigateTo(NavigationPath.Transactions);
    }

    private async Task Save()
    {
        var command = new SaveMemorabiliaTransaction.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);

        Snackbar.Add("Transaction was saved successfully!", Severity.Success);

        Id = command.Id;
    }
}
