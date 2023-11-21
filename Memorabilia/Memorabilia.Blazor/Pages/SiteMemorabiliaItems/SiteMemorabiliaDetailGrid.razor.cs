namespace Memorabilia.Blazor.Pages.SiteMemorabiliaItems;

public partial class SiteMemorabiliaDetailGrid : ReroutePage
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

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
        = [];

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

    private bool _canInteract;

    private bool _resetPaging;

    private MudTable<SiteMemorabiliaModel> _table
        = new();

    protected override void OnInitialized()
    {
        _canInteract
            = ApplicationStateService.CurrentUser != null &&
              ApplicationStateService.CurrentUser.HasPermission(Permission.Memorabilia);
    }

    protected override async Task OnParametersSetAsync()
    {
        if (!ReloadGrid)
            return;

        _resetPaging = true;

        await _table.ReloadServerData();

        _resetPaging = false;
    }

    protected async Task OnBuyNow()
    {
        if (!_canInteract)
        {
            await ShowMembershipDialog();
            return;
        }

        //TODO: Finish implimentation
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

    protected async Task OnMakeOffer(int memorabiliaId)
    {
        if (!_canInteract)
        {
            await ShowMembershipDialog();
            return;
        }

        NavigationManager.NavigateTo($"{NavigationPath.Offer}/{DataProtectorService.EncryptId(memorabiliaId)}");
    }

    protected async Task OnProposeTrade(int memorabiliaId)
    {
        if (!_canInteract)
        {
            await ShowMembershipDialog();
            return;
        }

        NavigationManager.NavigateTo($"{NavigationPath.ProposeTrade}/{DataProtectorService.EncryptId(memorabiliaId)}");
    }

    protected async Task<TableData<SiteMemorabiliaModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(_resetPaging ? 1 : state.Page + 1, state.PageSize);

        Model = UserId.HasValue
            ? await Mediator.Send(new GetUserSiteMemorabiliaItems(UserId.Value, pageInfo, Filter))
            : await Mediator.Send(new GetSiteMemorabiliaItems(pageInfo, Filter));

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
            ? []
            : Model.MemorabiliaItems.ToList();

        await MemorabiliaSelected.InvokeAsync(SelectedMemorabilia);
    }

    private void ToggleChildContent(int memorabiliaItemId)
    {
        SiteMemorabiliaModel memorabiliaItem = Model.MemorabiliaItems.Single(item => item.Id == memorabiliaItemId);

        memorabiliaItem.DisplayAutographDetails = !memorabiliaItem.DisplayAutographDetails;
    }
}
