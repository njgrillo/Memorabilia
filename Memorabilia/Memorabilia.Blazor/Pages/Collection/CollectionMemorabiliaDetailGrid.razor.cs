namespace Memorabilia.Blazor.Pages.Collection;

public partial class CollectionMemorabiliaDetailGrid
{ 
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public EventCallback AllMemorabiliaRemoved { get; set; }

    [Parameter]
    public int CollectionId { get; set; }

    [Parameter]
    public MemorabiliaSearchCriteria Filter { get; set; }    

    [Parameter]
    public EventCallback<List<MemorabiliaModel>> MemorabiliaSelected { get; set; }

    [Parameter]
    public bool ReloadGrid { get; set; }

    [Parameter]
    public List<MemorabiliaModel> SelectedMemorabilia { get; set; } 
        = new();

    protected MemorabiliasModel Model 
        = new();

    protected NoRecords NoRecords
        = new();

    protected string SelectAllButtonText
        => Model.MemorabiliaItems.Count == SelectedMemorabilia.Count
           ? "Deselect All"
           : "Select All";

    private MemorabiliaSearchCriteria _filter 
        = new();

    private bool _selectingMemorabilia;

    private bool _resetPaging;

    private MudTable<MemorabiliaModel> _table
        = new();

    protected override async Task OnParametersSetAsync()
    {
        if (_selectingMemorabilia)
        {
            _selectingMemorabilia = false;
            return;
        }

        if (ReloadGrid) 
        {
            await Load();
            ReloadGrid = false;
            return;
        }

        if (CollectionId == 0 || _filter == Filter)
            return;

        await Load();
    }    

    protected async Task OnMemorabiliaSelected(MemorabiliaModel item)
    {
        _selectingMemorabilia = true;

        if (!SelectedMemorabilia.Contains(item))
        {
            SelectedMemorabilia.Add(item);

            await MemorabiliaSelected.InvokeAsync(SelectedMemorabilia);

            return;
        }

        SelectedMemorabilia.Remove(item);

        await MemorabiliaSelected.InvokeAsync(SelectedMemorabilia);
    }

    protected async Task<TableData<MemorabiliaModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(_resetPaging ? 1 : state.Page + 1, state.PageSize);

        Model = Filter != null
            ? await Mediator.Send(new GetCollectionMemorabiliaItemsPaged(CollectionId, pageInfo, Filter))
            : await Mediator.Send(new GetCollectionMemorabiliaItemsPaged(CollectionId, pageInfo));

        StateHasChanged();

        return new TableData<MemorabiliaModel>()
        {
            Items = Model.MemorabiliaItems,
            TotalItems = Model.PageInfo.TotalItems
        };
    }

    protected async Task OnRemoveSelected()
    {
        int[] deletedIds = SelectedMemorabilia.Select(item => item.Id)
                                              .ToArray();

        if (!deletedIds.Any())
            return;

        await ShowRemoveMemorabiliaConfirm(deletedIds);
    }

    protected async Task OnSelectAll()
    {
        _selectingMemorabilia = true;

        SelectedMemorabilia = Model.MemorabiliaItems.Count == SelectedMemorabilia.Count
            ? new()
            : Model.MemorabiliaItems.ToList();

        await MemorabiliaSelected.InvokeAsync(SelectedMemorabilia);
    }

    protected async Task RemoveMemorabiliaItem(params int[] ids)
    {
        MemorabiliaModel[] itemsToDelete 
            = Model.MemorabiliaItems
                   .Where(item => ids.Contains(item.Id))
                   .ToArray();

        await Mediator.Send(new RemoveCollectionMemorabilia(CollectionId, ids));

        foreach (MemorabiliaModel item in itemsToDelete)
        {
            Model.MemorabiliaItems.Remove(item);
        }

        Snackbar.Add("Item(s) removed successfully!", Severity.Success);

        if (!Model.MemorabiliaItems.Any())
            await AllMemorabiliaRemoved.InvokeAsync();
    }

    protected async Task ShowRemoveMemorabiliaConfirm(params int[] ids)
    {
        var dialog = DialogService.Show<RemoveDialog>("Remove Memorabilia from Collection");
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        await RemoveMemorabiliaItem(ids);
    }

    private async Task Load()
    {
        _resetPaging = true;
        _filter = Filter;

        await _table.ReloadServerData();

        _resetPaging = false;
    }

    private void ToggleChildContent(int memorabiliaItemId)
    {
        MemorabiliaModel memorabiliaItem 
            = Model.MemorabiliaItems.Single(item => item.Id == memorabiliaItemId);

        memorabiliaItem.DisplayAutographDetails = !memorabiliaItem.DisplayAutographDetails;
    }
}
