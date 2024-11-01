namespace Memorabilia.Blazor.Pages.ForTrade;

public partial class ForTradeGrid
{
    [Inject]
    public ICourier Courier { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public MemorabiliaSearchCriteria Filter { get; set; }

    [Parameter]
    public bool ReloadGrid { get; set; }

    protected MemorabiliasModel Model
        = new();

    protected List<MemorabiliaModel> SelectedMemorabilia { get; set; }
        = [];

    protected string SelectAllButtonText
        => Model.MemorabiliaItems.Count == SelectedMemorabilia.Count
           ? "Deselect All"
           : "Select All";

    private bool _resetPaging;

    private MudTable<MemorabiliaModel> _table
        = new();

    protected override void OnInitialized()
    {
        Courier.Subscribe<ForTradeMemorabiliaAddedNotification>(OnMemorabiliaAdd);
    }

    protected override async Task OnParametersSetAsync()
    {
        if (!ReloadGrid)
            return;

        _resetPaging = true;

        await _table.ReloadServerData();

        _resetPaging = false;
    }

    public async Task OnMemorabiliaAdd(ForTradeMemorabiliaAddedNotification notification)
    {
        await _table.ReloadServerData();
    }

    protected void OnMemorabiliaSelected(MemorabiliaModel item)
    {
        if (!SelectedMemorabilia.Contains(item))
        {
            SelectedMemorabilia.Add(item);

            return;
        }

        SelectedMemorabilia.Remove(item);
    }

    protected async Task<TableData<MemorabiliaModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(_resetPaging ? 1 : state.Page + 1, state.PageSize);

        Model = Filter != null
            ? await Mediator.Send(new GetForTradeMemorabiliaItemsPaged(pageInfo, Filter))
            : await Mediator.Send(new GetForTradeMemorabiliaItemsPaged(pageInfo));

        StateHasChanged();

        switch (state.SortLabel)
        {
            case "item_field":
                Model.MemorabiliaItems = Model.MemorabiliaItems.OrderByDirection(state.SortDirection, o => o.ItemTypeName).ToList();
                break;
            case "condition_field":
                Model.MemorabiliaItems = Model.MemorabiliaItems.OrderByDirection(state.SortDirection, o => o.ConditionName).ToList();
                break;
            case "value_field":
                Model.MemorabiliaItems = Model.MemorabiliaItems.OrderByDirection(state.SortDirection, o => o.EstimatedValue).ToList();
                break;
            case "acquisitiontype_field":
                Model.MemorabiliaItems = Model.MemorabiliaItems.OrderByDirection(state.SortDirection, o => o.AcquisitionTypeName).ToList();
                break;
            case "acquisitiondate_field":
                Model.MemorabiliaItems = Model.MemorabiliaItems.OrderByDirection(state.SortDirection, o => o.Acquisition?.AcquiredDate).ToList();
                break;
            case "cost_field":
                Model.MemorabiliaItems = Model.MemorabiliaItems.OrderByDirection(state.SortDirection, o => o.Acquisition?.Cost).ToList();
                break;
            case "purchaseplace_field":
                Model.MemorabiliaItems = Model.MemorabiliaItems.OrderByDirection(state.SortDirection, o => o.PurchaseTypeName).ToList();
                break;
        }

        return new TableData<MemorabiliaModel>()
        {
            Items = Model.MemorabiliaItems,
            TotalItems = Model.PageInfo.TotalItems
        };
    }

    protected void OnSelectAll()
    {
        SelectedMemorabilia = Model.MemorabiliaItems.Count == SelectedMemorabilia.Count
            ? []
            : Model.MemorabiliaItems.ToList();
    }

    protected async Task RemoveMemorabiliaItem(params int[] ids)
    {
        MemorabiliaModel[] itemsToDelete
            = Model.MemorabiliaItems
                   .Where(item => ids.Contains(item.Id))
                   .ToArray();

        await Mediator.Send(new SaveForTradeMemorabilia.Command(removedMemorabiliaIds: ids));

        await _table.ReloadServerData();

        Snackbar.Add("Item(s) removed successfully!", Severity.Success);

        await Mediator.Publish(new ForTradeMemorabiliaRemovedNotification());
    }

    protected async Task RemoveSelected()
    {
        int[] ids
            = SelectedMemorabilia.Select(item => item.Memorabilia.Id)
                                 .ToArray();

        await Mediator.Send(new SaveForTradeMemorabilia.Command(removedMemorabiliaIds: ids));

        await _table.ReloadServerData();

        Snackbar.Add("Item(s) removed successfully!", Severity.Success);

        await Mediator.Publish(new ForTradeMemorabiliaRemovedNotification());
    }

    protected async Task ShowRemoveTradeMemorabiliaConfirm(params int[] ids)
    {
        var dialog = DialogService.Show<RemoveDialog>("Remove Memorabilia from Trade List");
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        await RemoveMemorabiliaItem(ids);
    }

    private void ToggleChildContent(int memorabiliaItemId)
    {
        MemorabiliaModel memorabiliaItem
            = Model.MemorabiliaItems.Single(item => item.Id == memorabiliaItemId);

        memorabiliaItem.DisplayAutographDetails = !memorabiliaItem.DisplayAutographDetails;
    }
}
