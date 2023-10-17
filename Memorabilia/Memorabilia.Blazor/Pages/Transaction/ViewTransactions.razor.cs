namespace Memorabilia.Blazor.Pages.Transaction;

public partial class ViewTransactions
{
    [Inject]
    public IMediator Mediator { get; set; }

    private bool _displayPartialTradeFilter;
    private bool _displayPurchaseFilter;
    private bool _displaySoldFilter;
    private bool _displayTradeFilter;

    private MemorabiliaSearchCriteria _filter
        = new();

    private int _partialTradeCount;
    private int _purchaseCount;
    private int _soldCount;
    private int _tradedCount;

    protected void OnFilter(MemorabiliaSearchCriteria filter)
    {
        _filter = filter;
    }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaTransactionsModel partialTradedItems 
            = await Mediator.Send(new GetPartialTradedMemorabiliaTransactionPaged(new PageInfo(1, 1)));

        _displayPartialTradeFilter = partialTradedItems.Items.Any();
        _partialTradeCount = partialTradedItems.PageInfo.TotalItems;

        PurchaseMemorabiliasModel purchasedItems = await Mediator.Send(new GetPurchaseMemorabiliaItemsPaged(new PageInfo(1, 1)));

        _displayPurchaseFilter = purchasedItems.MemorabiliaItems.Any();
        _purchaseCount = purchasedItems.PageInfo.TotalItems;

        MemorabiliaTransactionsModel soldItems = await Mediator.Send(new GetSoldMemorabiliaTransactionPaged(new PageInfo(1, 1)));

        _displaySoldFilter = soldItems.Items.Any();
        _soldCount = soldItems.PageInfo.TotalItems;

        MemorabiliaTransactionsModel tradedItems = await Mediator.Send(new GetTradedMemorabiliaTransactionPaged(new PageInfo(1, 1)));

        _displayTradeFilter = tradedItems.Items.Any();
        _tradedCount = tradedItems.PageInfo.TotalItems;
    }

    protected void OnPartialTradeTransactionDeleted()
    {
        _partialTradeCount = Math.Max(0, _partialTradeCount - 1);
        _displayPartialTradeFilter = _partialTradeCount > 0;
    }

    protected void OnSalesTransactionDeleted()
    {
        _soldCount = Math.Max(0, _soldCount - 1);
        _displaySoldFilter = _soldCount > 0;
    }

    protected void OnTradeTransactionDeleted()
    {
        _tradedCount = Math.Max(0, _tradedCount - 1);
        _displayTradeFilter = _tradedCount > 0;
    }
}
