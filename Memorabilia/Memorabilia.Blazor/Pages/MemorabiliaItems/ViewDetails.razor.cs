namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public partial class ViewDetails : ImagePage
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public int UserId { get; set; }

    private MemorabiliaSearchCriteria _filter = new();
    private bool _resetPaging;
    private MudTable<MemorabiliaItemModel> _table;
    private MemorabiliaItemsModel _viewModel = new();

    protected async Task DeleteAutograph(int id)
    {
        var itemToDelete = _viewModel.MemorabiliaItems
                                     .SelectMany(item => item.Autographs)
                                     .Single(autograph => autograph.Id == id);

        var viewModel = new AutographEditModel(itemToDelete)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveAutograph.Command(viewModel));

        var memorabiliaItem = _viewModel.MemorabiliaItems.First(item => item.Id == itemToDelete.MemorabiliaId);
        memorabiliaItem.Autographs.Remove(itemToDelete);

        Snackbar.Add($"Autograph was deleted successfully!", Severity.Success);
    }

    protected async Task DeleteMemorabiliaItem(int id)
    {
        var itemToDelete = _viewModel.MemorabiliaItems.Single(item => item.Id == id);
        var viewModel = new MemorabiliaItemEditModel(itemToDelete)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveMemorabiliaItem.Command(viewModel));

        _viewModel.MemorabiliaItems.Remove(itemToDelete);

        Snackbar.Add($"{itemToDelete.ItemTypeName} was deleted successfully!", Severity.Success);
    }

    protected async Task OnFilter(MemorabiliaSearchCriteria filter)
    {
        _filter = filter;
        _resetPaging = true;

        await _table.ReloadServerData();
    }

    protected async Task<TableData<MemorabiliaItemModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(_resetPaging ? 1 : state.Page + 1, state.PageSize);

        _viewModel = _filter != null
            ? await QueryRouter.Send(new GetMemorabiliaItemsPaged(UserId, pageInfo, _filter))
            : await QueryRouter.Send(new GetMemorabiliaItemsPaged(UserId, pageInfo));

        return new TableData<MemorabiliaItemModel>() { Items = _viewModel.MemorabiliaItems, 
                                                           TotalItems = _viewModel.PageInfo.TotalItems };
    }

    protected async Task ShowDeleteAutographConfirm(int id)
    {
        var dialog = DialogService.Show<DeleteDialog>("Delete Autograph");
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        await DeleteAutograph(id);
    }

    protected async Task ShowDeleteMemorabiliaConfirm(int id)
    {
        var dialog = DialogService.Show<DeleteDialog>("Delete Memorabilia");
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        await DeleteMemorabiliaItem(id);
    }

    private void ToggleChildContent(int memorabiliaItemId)
    {
        var memorabiliaItem = _viewModel.MemorabiliaItems.Single(item => item.Id == memorabiliaItemId);
        memorabiliaItem.DisplayAutographDetails = !memorabiliaItem.DisplayAutographDetails;
        memorabiliaItem.ToggleIcon = memorabiliaItem.DisplayAutographDetails 
            ? Icons.Material.Filled.ExpandLess
            : Icons.Material.Filled.ExpandMore;
    }
}
