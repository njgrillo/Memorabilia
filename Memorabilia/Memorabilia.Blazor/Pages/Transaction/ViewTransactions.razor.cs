using Memorabilia.Application.Services.Filters.Memorabilia.Rules;

namespace Memorabilia.Blazor.Pages.Transaction;

public partial class ViewTransactions
{
    [Inject]
    public IMediator Mediator { get; set; }

    protected bool ReloadPartialTradeGrid { get; set; }

    protected bool ReloadPurchaseGrid { get; set; }

    protected bool ReloadSalesGrid { get; set; }

    protected bool ReloadTradeGrid { get; set; }

    private bool _displayPartialTradeFilter;
    private bool _displayPurchaseFilter;
    private bool _displaySoldFilter;
    private bool _displayTradeFilter;

    private MemorabiliaSearchCriteria _partialTradeFilter
        = new();

    private MemorabiliaSearchCriteria _purchaseFilter
        = new();

    private MemorabiliaSearchCriteria _salesFilter
        = new();

    private MemorabiliaSearchCriteria _tradeFilter
        = new();

    private int _partialTradeCount;
    private int _purchaseCount;
    private int _soldCount;
    private int _tradedCount;

    protected void OnPartialTradeFilter(MemorabiliaSearchCriteria filter)
    {
        _partialTradeFilter = filter;
        ReloadPartialTradeGrid = true;
    }

    protected void OnPurchaseFilter(MemorabiliaSearchCriteria filter)
    {
        _purchaseFilter = filter;
        ReloadPurchaseGrid = true;
    }

    protected void OnSalesFilter(MemorabiliaSearchCriteria filter)
    {
        _salesFilter = filter;
        ReloadSalesGrid = true;
    }

    protected void OnTradeFilter(MemorabiliaSearchCriteria filter)
    {
        _tradeFilter = filter;
        ReloadTradeGrid = true;
    }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaTransactionsModel partialTradedItems 
            = await Mediator.Send(new GetPartialTradedMemorabiliaTransactionPaged(new PageInfo(1, 1)));

        _displayPartialTradeFilter = partialTradedItems.Items.Count != 0;
        _partialTradeCount = partialTradedItems.PageInfo.TotalItems;

        PurchaseMemorabiliasModel purchasedItems = await Mediator.Send(new GetPurchaseMemorabiliaItemsPaged(new PageInfo(1, 1)));

        _displayPurchaseFilter = purchasedItems.MemorabiliaItems.Count != 0;
        _purchaseCount = purchasedItems.PageInfo.TotalItems;

        MemorabiliaTransactionsModel soldItems = await Mediator.Send(new GetSoldMemorabiliaTransactionPaged(new PageInfo(1, 1)));

        _displaySoldFilter = soldItems.Items.Count != 0;
        _soldCount = soldItems.PageInfo.TotalItems;

        MemorabiliaTransactionsModel tradedItems = await Mediator.Send(new GetTradedMemorabiliaTransactionPaged(new PageInfo(1, 1)));

        _displayTradeFilter = tradedItems.Items.Count != 0;
        _tradedCount = tradedItems.PageInfo.TotalItems;

        StateHasChanged();
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
