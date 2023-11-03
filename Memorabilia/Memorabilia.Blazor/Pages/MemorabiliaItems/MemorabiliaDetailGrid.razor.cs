namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public partial class MemorabiliaDetailGrid
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
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public bool CanSelect { get; set; }

    [Parameter]
    public List<MemorabiliaModel> DisplayItems { get; set; }

    [Parameter]
    public MemorabiliaSearchCriteria Filter { get; set; }
        = new();

    [Parameter]
    public EventCallback GridLoaded { get; set; }    

    [Parameter]
    public EventCallback<List<MemorabiliaModel>> MemorabiliaSelected { get; set; }

    [Parameter]
    public bool ReloadGrid { get; set; }

    [Parameter]
    public List<MemorabiliaModel> SelectedMemorabilia { get; set; } 
        = new();

    [Parameter]
    public bool ShowActions { get; set; } 
        = true;

    protected MemorabiliasModel Model 
        = new();

    protected string SelectAllButtonText
        => Model.MemorabiliaItems.Count == SelectedMemorabilia.Count
           ? "Deselect All"
           : "Select All";

    private bool _resetPaging;

    private MudTable<MemorabiliaModel> _table 
        = new();

    protected override async Task OnParametersSetAsync()
    {
        if (Model.MemorabiliaItems.Any() && !ReloadGrid)
            return;

        _resetPaging = true;

        await _table.ReloadServerData();
        
        _resetPaging = false;
    }

    protected async Task DeleteAutograph(int id)
    {
        AutographModel itemToDelete = Model.MemorabiliaItems
                                           .SelectMany(item => item.Autographs)
                                           .Single(autograph => autograph.Id == id);

        var editModel = new AutographEditModel(itemToDelete)
        {
            IsDeleted = true
        };

        await Mediator.Send(new SaveAutograph.Command(editModel));

        MemorabiliaModel memorabiliaItem 
            = Model.MemorabiliaItems.First(item => item.Id == itemToDelete.MemorabiliaId);

        memorabiliaItem.Autographs.Remove(itemToDelete);

        Snackbar.Add($"Autograph was deleted successfully!", Severity.Success);
    }

    protected async Task DeleteMemorabiliaItem(int id)
    {
        MemorabiliaModel itemToDelete = Model.MemorabiliaItems.Single(item => item.Id == id);

        var editModel = new MemorabiliaEditModel(itemToDelete)
        {
            IsDeleted = true
        };

        await Mediator.Send(new SaveMemorabiliaItem.Command(editModel));

        Model.MemorabiliaItems.Remove(itemToDelete);

        Snackbar.Add($"{itemToDelete.ItemTypeName} was deleted successfully!", Severity.Success);
    }

    protected void OnImageLoaded()
    {
        StateHasChanged();
    }

    protected async Task OnMemorabiliaSelected(MemorabiliaModel item)
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

    protected async Task<TableData<MemorabiliaModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(_resetPaging ? 1 : state.Page + 1, state.PageSize);

        Model = await Mediator.Send(new GetMemorabiliaItemsPaged(pageInfo, Filter));

        await GridLoaded.InvokeAsync();

        return new TableData<MemorabiliaModel>()
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

    protected async Task ShowPersonProfileDialog(int personId)
    {
        var parameters = new DialogParameters
        {
            ["PersonId"] = personId
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.ExtraLarge,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<PersonProfileDialog>(string.Empty, parameters, options);

        await dialog.Result;
    }

    private void ToggleChildContent(int memorabiliaItemId)
    {
        MemorabiliaModel memorabiliaItem = Model.MemorabiliaItems.Single(item => item.Id == memorabiliaItemId);

        memorabiliaItem.DisplayAutographDetails = !memorabiliaItem.DisplayAutographDetails;
        memorabiliaItem.ToggleIcon = memorabiliaItem.DisplayAutographDetails
            ? Icons.Material.Filled.ExpandLess
            : Icons.Material.Filled.ExpandMore;
    }
}
