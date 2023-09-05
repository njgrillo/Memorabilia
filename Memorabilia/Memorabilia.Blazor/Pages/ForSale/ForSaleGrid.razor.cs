namespace Memorabilia.Blazor.Pages.ForSale;

public partial class ForSaleGrid
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

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
    public QueryRouter QueryRouter { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public MemorabiliaSearchCriteria Filter { get; set; }

    protected ForSaleEditModel Model
        = new();

    protected List<ForSaleMemorabiliaEditModel> SelectedMemorabilia { get; set; }
        = new();

    protected string SelectAllButtonText
        => Model.Items.Count == SelectedMemorabilia.Count
           ? "Deselect All"
           : "Select All";

    private ForSaleMemorabiliaEditModel _elementBeforeEdit;

    private MemorabiliaSearchCriteria _filter
        = new();

    private bool _resetPaging;

    private MudTable<ForSaleMemorabiliaEditModel> _table
        = new();

    protected override void OnInitialized()
    {
        Courier.Subscribe<ForSaleMemorabiliaAddedNotification>(OnMemorabiliaAdd);
    }

    protected override async Task OnParametersSetAsync()
    {
        if (_filter == Filter)
            return;

        _resetPaging = true;
        _filter = Filter;

        await _table.ReloadServerData();

        _resetPaging = false;
    }    

    protected void OnImageLoaded()
    {
        StateHasChanged();
    }

    public async Task OnMemorabiliaAdd(ForSaleMemorabiliaAddedNotification notification)
    {
        await _table.ReloadServerData();
    }

    protected void OnMemorabiliaSelected(ForSaleMemorabiliaEditModel item)
    {
        if (!SelectedMemorabilia.Contains(item))
        {
            SelectedMemorabilia.Add(item);

            return;
        }

        SelectedMemorabilia.Remove(item);
    }

    protected async Task<TableData<ForSaleMemorabiliaEditModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(_resetPaging ? 1 : state.Page + 1, state.PageSize);

        ForSaleModel model = Filter != null
            ? await QueryRouter.Send(new GetForSaleMemorabiliaItemsPaged(pageInfo, Filter))
            : await QueryRouter.Send(new GetForSaleMemorabiliaItemsPaged(pageInfo));

        Model = new(model);

        return new TableData<ForSaleMemorabiliaEditModel>()
        {
            Items = Model.Items,
            TotalItems = model.PageInfo.TotalItems
        };
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveForSaleMemorabilia.Command(Model));

        await _table.ReloadServerData();

        Snackbar.Add("Item(s) saved successfully!", Severity.Success);

        await Mediator.Publish(new ForSaleMemorabiliaAddedNotification());
    }

    protected void OnSelectAll()
    {
        SelectedMemorabilia = Model.Items.Count == SelectedMemorabilia.Count
            ? new()
            : Model.Items.ToList();
    }

    protected async Task RemoveMemorabiliaItem(params int[] ids)
    {
        await CommandRouter.Send(new SaveForSaleMemorabilia.Command(removedIds: ids));

        await _table.ReloadServerData();

        Snackbar.Add("Item(s) removed successfully!", Severity.Success);

        await Mediator.Publish(new ForSaleMemorabiliaRemovedNotification());
    }

    protected async Task RemoveSelected()
    {
        int[] ids
            = SelectedMemorabilia.Select(item => item.Id)
                                 .ToArray();

        await CommandRouter.Send(new SaveForSaleMemorabilia.Command(removedIds: ids));

        await _table.ReloadServerData();

        Snackbar.Add("Item(s) removed successfully!", Severity.Success);

        await Mediator.Publish(new ForSaleMemorabiliaRemovedNotification());
    }

    protected async Task ShowRemoveSaleMemorabiliaConfirm(params int[] ids)
    {
        var dialog = DialogService.Show<RemoveDialog>("Remove Memorabilia from Sale List");
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        await RemoveMemorabiliaItem(ids);
    }

    private void BackupItem(object element)
    {
        _elementBeforeEdit = new()
        {
            AllowBestOffer = ((ForSaleMemorabiliaEditModel)element).AllowBestOffer,
            BuyNowPrice = ((ForSaleMemorabiliaEditModel)element).BuyNowPrice,
            MinimumOfferPrice = ((ForSaleMemorabiliaEditModel)element).MinimumOfferPrice
        };
    }

    private void ResetItemToOriginalValues(object element)
    {
        ((ForSaleMemorabiliaEditModel)element).AllowBestOffer = _elementBeforeEdit.AllowBestOffer;
        ((ForSaleMemorabiliaEditModel)element).BuyNowPrice = _elementBeforeEdit.BuyNowPrice;
        ((ForSaleMemorabiliaEditModel)element).MinimumOfferPrice = _elementBeforeEdit.MinimumOfferPrice;
    }
}
