namespace Memorabilia.Blazor.Pages.Transaction;

public partial class SalesGrid
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

    protected async Task<TableData<MemorabiliaTransactionModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(_resetPaging ? 1 : state.Page + 1, state.PageSize);

        Model = Filter != null
            ? await Mediator.Send(new GetSoldMemorabiliaTransactionPaged(pageInfo, Filter))
            : await Mediator.Send(new GetSoldMemorabiliaTransactionPaged(pageInfo));

        return new TableData<MemorabiliaTransactionModel>()
        {
            Items = Model.Items,
            TotalItems = Model.PageInfo.TotalItems
        };
    }

    protected async Task DeleteSale(int memorabiliaTransactionId, int memorabiliaTransactionSaleId)
    {
        MemorabiliaTransactionModel transaction = Model.Items.Single(item => item.MemorabiliaTransactionId == memorabiliaTransactionId);   

        var editModel = new MemorabiliaTransactionEditModel(transaction);

        MemorabiliaTransactionSaleEditModel deletedSale = editModel.Sales.SingleOrDefault(sale => sale.Id == memorabiliaTransactionSaleId);

        if (deletedSale != null)
        {
            deletedSale.IsDeleted = true;

            await Mediator.Send(new SaveMemorabiliaTransaction.Command(editModel));

            transaction.DisplayDetails = editModel.Sales.Any(sale => !sale.IsDeleted);
        }

        Snackbar.Add($"Sale was deleted successfully!", Severity.Success);

        StateHasChanged();
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
        memorabiliaTransactionModel.ToggleIcon = memorabiliaTransactionModel.DisplayDetails
            ? Icons.Material.Filled.ExpandLess
            : Icons.Material.Filled.ExpandMore;
    }
}
