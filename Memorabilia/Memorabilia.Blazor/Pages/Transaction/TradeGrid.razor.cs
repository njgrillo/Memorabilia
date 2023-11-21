namespace Memorabilia.Blazor.Pages.Transaction;

public partial class TradeGrid
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public MemorabiliaSearchCriteria Filter { get; set; }

    [Parameter]
    public EventCallback GridLoaded { get; set; }

    [Parameter]
    public bool ReloadGrid { get; set; }

    [Parameter]
    public EventCallback TransactionDeleted { get; set; }

    protected MemorabiliaTransactionsModel Model
        = new();

    private bool _resetPaging;

    private MudTable<MemorabiliaTransactionModel> _table
        = new();

    protected override async Task OnParametersSetAsync()
    {
        if (!ReloadGrid)
            return;

        _resetPaging = true;

        await _table.ReloadServerData();

        _resetPaging = false;
    }

    protected async Task<TableData<MemorabiliaTransactionModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(_resetPaging ? 1 : state.Page + 1, state.PageSize);

        Model = await Mediator.Send(new GetTradedMemorabiliaTransactionPaged(pageInfo, Filter));

        await GridLoaded.InvokeAsync();

        return new TableData<MemorabiliaTransactionModel>()
        {
            Items = Model.Items,
            TotalItems = Model.PageInfo.TotalItems
        };
    }

    protected async Task DeleteTrade(int memorabiliaTransactionId, int memorabiliaTransactionTradeId)
    {
        MemorabiliaTransactionModel transaction = Model.Items.Single(item => item.MemorabiliaTransactionId == memorabiliaTransactionId);

        var editModel = new MemorabiliaTransactionEditModel(transaction);

        MemorabiliaTransactionTradeEditModel deletedTrade = editModel.Trades.SingleOrDefault(trade => trade.Id == memorabiliaTransactionTradeId);

        if (deletedTrade != null)
        {
            deletedTrade.IsDeleted = true;

            await Mediator.Send(new SaveMemorabiliaTransaction.Command(editModel));

            transaction.DisplayDetails = editModel.Trades.Any(trade => !trade.IsDeleted);
        }

        Snackbar.Add($"Trade was deleted successfully!", Severity.Success);
    }

    protected async Task DeleteTransaction(int id)
    {
        MemorabiliaTransactionModel itemToDelete = Model.Items.Single(item => item.MemorabiliaTransactionId == id);

        var editModel = new MemorabiliaTransactionEditModel(itemToDelete)
        {
            IsDeleted = true
        };

        await Mediator.Send(new SaveMemorabiliaTransaction.Command(editModel));

        Model.Items.Remove(itemToDelete);

        Snackbar.Add($"Transaction was deleted successfully!", Severity.Success);

        await TransactionDeleted.InvokeAsync();
    }

    private void ToggleChildContent(int memorabiliaTransactionId)
    {
        MemorabiliaTransactionModel memorabiliaTransactionModel
            = Model.Items.Single(item => item.MemorabiliaTransactionId == memorabiliaTransactionId);

        memorabiliaTransactionModel.DisplayDetails = !memorabiliaTransactionModel.DisplayDetails;
    }
}
