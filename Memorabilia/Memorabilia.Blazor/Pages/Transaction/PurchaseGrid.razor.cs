using Memorabilia.Application.Services.Interfaces;

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
    public List<PurchaseMemorabiliaModel> DisplayItems { get; set; }

    [Parameter]
    public MemorabiliaSearchCriteria Filter { get; set; }

    protected PurchaseMemorabiliasModel Model
        = new();

    private bool _resetPaging;

    private MudTable<PurchaseMemorabiliaModel> _table
        = new();

    protected override async Task OnParametersSetAsync()
    {
        _resetPaging = true;

        await _table.ReloadServerData();

        _resetPaging = false;
    }

    protected async Task<TableData<PurchaseMemorabiliaModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(_resetPaging ? 1 : state.Page + 1, state.PageSize);

        Model = Filter != null
            ? await Mediator.Send(new GetPurchaseMemorabiliaItemsPaged(pageInfo, Filter))
            : await Mediator.Send(new GetPurchaseMemorabiliaItemsPaged(pageInfo));

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
