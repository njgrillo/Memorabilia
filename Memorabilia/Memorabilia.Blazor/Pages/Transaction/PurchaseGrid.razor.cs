namespace Memorabilia.Blazor.Pages.Transaction;

public partial class PurchaseGrid
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public MemorabiliaSearchCriteria Filter { get; set; }

    [Parameter]
    public EventCallback GridLoaded { get; set; }

    [Parameter]
    public bool ReloadGrid { get; set; }

    protected PurchaseMemorabiliasModel Model
        = new();

    private bool _resetPaging;

    private MudTable<PurchaseMemorabiliaModel> _table
        = new();

    protected override async Task OnParametersSetAsync()
    {
        if (!ReloadGrid)
            return;

        _resetPaging = true;

        await _table.ReloadServerData();

        _resetPaging = false;
    }

    protected async Task<TableData<PurchaseMemorabiliaModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(_resetPaging ? 1 : state.Page + 1, state.PageSize);

        Model = await Mediator.Send(new GetPurchaseMemorabiliaItemsPaged(pageInfo, Filter));

        await GridLoaded.InvokeAsync();

        return new TableData<PurchaseMemorabiliaModel>()
        {
            Items = Model.MemorabiliaItems,
            TotalItems = Model.PageInfo.TotalItems
        };
    }

    private void ToggleChildContent(int memorabiliaItemId)
    {
        PurchaseMemorabiliaModel memorabiliaItem 
            = Model.MemorabiliaItems.Single(item => item.Id == memorabiliaItemId);

        memorabiliaItem.DisplayAutographDetails = !memorabiliaItem.DisplayAutographDetails;
    }
}
