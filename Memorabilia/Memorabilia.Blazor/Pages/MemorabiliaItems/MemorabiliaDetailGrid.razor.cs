namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public partial class MemorabiliaDetailGrid
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public bool CanSelect { get; set; }

    [Parameter]
    public List<MemorabiliaItemModel> DisplayItems { get; set; } 

    [Parameter]
    public MemorabiliaSearchCriteria Filter { get; set; }

    [Parameter]
    public EventCallback<List<MemorabiliaItemModel>> MemorabiliaSelected { get; set; }

    [Parameter]
    public List<MemorabiliaItemModel> SelectedMemorabilia { get; set; } = new();

    [Parameter]
    public bool ShowActions { get; set; } = true;

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
        if (UserId == 0 || _filter == Filter)
            return;

        _resetPaging = true;
        _filter = Filter;

        await _table.ReloadServerData();
        
        _resetPaging = false;
    }

    protected async Task DeleteAutograph(int id)
    {
        AutographModel itemToDelete = Model.MemorabiliaItems
                                           .SelectMany(item => item.Autographs)
                                           .Single(autograph => autograph.Id == id);

        var viewModel = new AutographEditModel(itemToDelete)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveAutograph.Command(viewModel));

        MemorabiliaItemModel memorabiliaItem 
            = Model.MemorabiliaItems.First(item => item.Id == itemToDelete.MemorabiliaId);

        memorabiliaItem.Autographs.Remove(itemToDelete);

        Snackbar.Add($"Autograph was deleted successfully!", Severity.Success);
    }

    protected async Task DeleteMemorabiliaItem(int id)
    {
        MemorabiliaItemModel itemToDelete = Model.MemorabiliaItems.Single(item => item.Id == id);
        var viewModel = new MemorabiliaItemEditModel(itemToDelete)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveMemorabiliaItem.Command(viewModel));

        Model.MemorabiliaItems.Remove(itemToDelete);

        Snackbar.Add($"{itemToDelete.ItemTypeName} was deleted successfully!", Severity.Success);
    }

    protected void OnImageLoaded()
    {
        StateHasChanged();
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
            ? await QueryRouter.Send(new GetMemorabiliaItemsPaged(UserId, pageInfo, Filter))
            : await QueryRouter.Send(new GetMemorabiliaItemsPaged(UserId, pageInfo));

        return new TableData<MemorabiliaItemModel>()
        {
            Items = Model.MemorabiliaItems,
            TotalItems = Model.PageInfo.TotalItems
        };
    }

    protected async Task OnSelectAll()
    {
        SelectedMemorabilia = Model.MemorabiliaItems.Count == SelectedMemorabilia.Count
            ? new()
            : Model.MemorabiliaItems.ToList();

        await MemorabiliaSelected.InvokeAsync(SelectedMemorabilia);
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
        MemorabiliaItemModel memorabiliaItem = Model.MemorabiliaItems.Single(item => item.Id == memorabiliaItemId);

        memorabiliaItem.DisplayAutographDetails = !memorabiliaItem.DisplayAutographDetails;
        memorabiliaItem.ToggleIcon = memorabiliaItem.DisplayAutographDetails
            ? Icons.Material.Filled.ExpandLess
            : Icons.Material.Filled.ExpandMore;
    }
}
