﻿namespace Memorabilia.Blazor.Pages.Collection;

public partial class CollectionMemorabiliaDetailGrid
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public int CollectionId { get; set; }

    [Parameter]
    public MemorabiliaSearchCriteria Filter { get; set; }

    [Parameter]
    public EventCallback<List<MemorabiliaItemModel>> MemorabiliaSelected { get; set; }

    [Parameter]
    public List<MemorabiliaItemModel> SelectedMemorabilia { get; set; } = new();

    [Parameter]
    public int UserId { get; set; }

    protected MemorabiliaItemsModel Model = new();

    protected string SelectAllButtonText
        => Model.MemorabiliaItems.Count == SelectedMemorabilia.Count
           ? "Deselect All"
           : "Select All";

    private MemorabiliaSearchCriteria _filter = new();
    private bool _resetPaging;
    private MudTable<MemorabiliaItemModel> _table = new();

    protected override async Task OnParametersSetAsync()
    {
        if (CollectionId == 0 || _filter == Filter)
            return;

        _resetPaging = true;
        _filter = Filter;

        await _table.ReloadServerData();

        _resetPaging = false;
    }

    protected async Task RemoveMemorabiliaItem(params int[] ids)
    {
        MemorabiliaItemModel[] itemsToDelete = Model.MemorabiliaItems.Where(item => ids.Contains(item.Id)).ToArray();

        await CommandRouter.Send(new RemoveCollectionMemorabilia(CollectionId, ids));

        foreach (MemorabiliaItemModel item in itemsToDelete)
        {
            Model.MemorabiliaItems.Remove(item);
        }        

        Snackbar.Add("Item(s) removed successfully!", Severity.Success);
    }

    protected async Task OnMemorabiliaSelected(MemorabiliaItemModel item)
    {
        if (!SelectedMemorabilia.Contains(item))
        {
            SelectedMemorabilia.Add(item);

            await MemorabiliaSelected.InvokeAsync(SelectedMemorabilia);

            return;
        }

        SelectedMemorabilia.Remove(item);

        await MemorabiliaSelected.InvokeAsync(SelectedMemorabilia);
    }

    protected async Task<TableData<MemorabiliaItemModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(_resetPaging ? 1 : state.Page + 1, state.PageSize);

        Model = Filter != null
            ? await QueryRouter.Send(new GetCollectionMemorabiliaItemsPaged(CollectionId, pageInfo, Filter))
            : await QueryRouter.Send(new GetCollectionMemorabiliaItemsPaged(CollectionId, pageInfo));

        return new TableData<MemorabiliaItemModel>()
        {
            Items = Model.MemorabiliaItems,
            TotalItems = Model.PageInfo.TotalItems
        };
    }

    protected async Task OnRemoveSelected()
    {
        int[] deletedIds = SelectedMemorabilia.Select(item => item.Id).ToArray();

        if (!deletedIds.Any())
            return;

        await ShowRemoveMemorabiliaConfirm(deletedIds);
    }

    protected async Task OnSelectAll()
    {
        SelectedMemorabilia = Model.MemorabiliaItems.Count == SelectedMemorabilia.Count
            ? new()
            : Model.MemorabiliaItems.ToList();

        await MemorabiliaSelected.InvokeAsync(SelectedMemorabilia);
    }

    protected async Task ShowRemoveMemorabiliaConfirm(params int[] ids)
    {
        var dialog = DialogService.Show<RemoveDialog>("Remove Memorabilia from Collection");
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        await RemoveMemorabiliaItem(ids);
    }

    private void ToggleChildContent(int memorabiliaItemId)
    {
        MemorabiliaItemModel memorabiliaItem = Model.MemorabiliaItems.Single(item => item.Id == memorabiliaItemId);

        memorabiliaItem.DisplayAutographDetails = !memorabiliaItem.DisplayAutographDetails;
        memorabiliaItem.ToggleIcon = memorabiliaItem.DisplayAutographDetails
            ? Icons.Material.Filled.ExpandLess
            : Icons.Material.Filled.ExpandMore;
    }
}
