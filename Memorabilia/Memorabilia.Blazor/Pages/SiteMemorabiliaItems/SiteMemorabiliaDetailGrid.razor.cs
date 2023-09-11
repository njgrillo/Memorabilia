﻿namespace Memorabilia.Blazor.Pages.SiteMemorabiliaItems;

public partial class SiteMemorabiliaDetailGrid
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public bool CanSelect { get; set; }

    [Parameter]
    public MemorabiliaSearchCriteria Filter { get; set; }

    [Parameter]
    public EventCallback<List<SiteMemorabiliaModel>> MemorabiliaSelected { get; set; }

    [Parameter]
    public EventCallback GridLoaded { get; set; }

    [Parameter]
    public bool ReloadGrid { get; set; }

    [Parameter]
    public List<SiteMemorabiliaModel> SelectedMemorabilia { get; set; }
        = new();

    [Parameter]
    public bool ShowActions { get; set; }
        = true;

    [Parameter]
    public int? UserId { get; set; }

    protected SiteMemorabiliasModel Model
        = new();

    protected string SelectAllButtonText
        => Model.MemorabiliaItems.Count == SelectedMemorabilia.Count
           ? "Deselect All"
           : "Select All";

    private MemorabiliaSearchCriteria _filter
        = new();

    private bool _resetPaging;

    private MudTable<SiteMemorabiliaModel> _table
        = new();

    protected override async Task OnParametersSetAsync()
    {
        if (Model.MemorabiliaItems.Any() && !ReloadGrid)
            return;

        _resetPaging = true;
        _filter = Filter;

        await _table.ReloadServerData();

        _resetPaging = false;
    }

    protected void OnBuyNow()
    {

    }

    protected void OnImageLoaded()
    {
        StateHasChanged();
    }

    protected async Task OnMemorabiliaSelected(SiteMemorabiliaModel item)
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

    protected void OnMakeOffer()
    {

    }

    protected void OnProposeTrade(int memorabiliaId)
    {
        NavigationManager.NavigateTo($"{NavigationPath.ProposeTrade}/{DataProtectorService.EncryptId(memorabiliaId)}");
    }

    protected async Task<TableData<SiteMemorabiliaModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(_resetPaging ? 1 : state.Page + 1, state.PageSize);

        Model = UserId.HasValue
            ? await QueryRouter.Send(new GetUserSiteMemorabiliaItems(UserId.Value, pageInfo, Filter))
            : await QueryRouter.Send(new GetSiteMemorabiliaItems(pageInfo, Filter));

        await GridLoaded.InvokeAsync();

        return new TableData<SiteMemorabiliaModel>()
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

    private void ToggleChildContent(int memorabiliaItemId)
    {
        SiteMemorabiliaModel memorabiliaItem = Model.MemorabiliaItems.Single(item => item.Id == memorabiliaItemId);

        memorabiliaItem.DisplayAutographDetails = !memorabiliaItem.DisplayAutographDetails;
        memorabiliaItem.ToggleIcon = memorabiliaItem.DisplayAutographDetails
            ? Icons.Material.Filled.ExpandLess
            : Icons.Material.Filled.ExpandMore;
    }
}
