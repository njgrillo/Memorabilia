namespace Memorabilia.Blazor.Pages.Transaction;

public partial class PartialTradeGrid
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public MemorabiliaSearchCriteria Filter { get; set; }

    [Parameter]
    public EventCallback TransactionDeleted { get; set; }

    protected MemorabiliaTransactionsModel Model
        = new();

    private bool _resetPaging;

    private MudTable<MemorabiliaTransactionModel> _table
        = new();

    protected override async Task OnParametersSetAsync()
    {
        _resetPaging = true;

        await _table.ReloadServerData();

        _resetPaging = false;
    }

    protected void OnImageLoaded()
    {
        StateHasChanged();
    }

    protected async Task<TableData<MemorabiliaTransactionModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(_resetPaging ? 1 : state.Page + 1, state.PageSize);

        Model = Filter != null
            ? await QueryRouter.Send(new GetPartialTradedMemorabiliaTransactionPaged(pageInfo, Filter))
            : await QueryRouter.Send(new GetPartialTradedMemorabiliaTransactionPaged(pageInfo));

        return new TableData<MemorabiliaTransactionModel>()
        {
            Items = Model.Items,
            TotalItems = Model.PageInfo.TotalItems
        };
    }

    protected async Task ShowDeleteTransactionConfirm(int id)
    {
        var dialog = DialogService.Show<DeleteDialog>("Delete Transaction");
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        await DeleteTransaction(id);
    }

    protected async Task ShowDeleteTransactionTradeConfirm(int memorabiliaTransactionId, int memorabiliaTransactionTradeId)
    {
        var dialog = DialogService.Show<DeleteDialog>("Delete Partial Trade");
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        await DeleteTrade(memorabiliaTransactionId, memorabiliaTransactionTradeId);
    }

    protected async Task DeleteTrade(int memorabiliaTransactionId, int memorabiliaTransactionTradeId)
    {
        MemorabiliaTransactionModel transaction = Model.Items.Single(item => item.MemorabiliaTransactionId == memorabiliaTransactionId);

        var editModel = new MemorabiliaTransactionEditModel(transaction);

        MemorabiliaTransactionTradeEditModel deletedTrade = editModel.Trades.SingleOrDefault(trade => trade.Id == memorabiliaTransactionTradeId);

        if (deletedTrade != null)
        {
            deletedTrade.IsDeleted = true;

            await CommandRouter.Send(new SaveMemorabiliaTransaction.Command(editModel));

            transaction.DisplayDetails = editModel.Trades.Any(trade => !trade.IsDeleted);
        }

        Snackbar.Add($"Partial Trade was deleted successfully!", Severity.Success);
    }

    protected async Task DeleteTransaction(int id)
    {
        MemorabiliaTransactionModel itemToDelete = Model.Items.Single(item => item.MemorabiliaTransactionId == id);

        var editModel = new MemorabiliaTransactionEditModel(itemToDelete)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveMemorabiliaTransaction.Command(editModel));

        Model.Items.Remove(itemToDelete);

        Snackbar.Add($"Transaction was deleted successfully!", Severity.Success);

        await TransactionDeleted.InvokeAsync();
    }

    private void ToggleChildContent(int memorabiliaTransactionId)
    {
        MemorabiliaTransactionModel memorabiliaTransactionModel
            = Model.Items.Single(item => item.MemorabiliaTransactionId == memorabiliaTransactionId);

        memorabiliaTransactionModel.DisplayDetails = !memorabiliaTransactionModel.DisplayDetails;
        memorabiliaTransactionModel.ToggleIcon = memorabiliaTransactionModel.DisplayDetails
            ? Icons.Material.Filled.ExpandLess
            : Icons.Material.Filled.ExpandMore;
    }
}
