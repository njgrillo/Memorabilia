namespace Memorabilia.Blazor.Pages.Collection;

public partial class CollectionMemorabiliaGalleryGrid
{
    [Inject]
    public IGalleryService GalleryService { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int CollectionId { get; set; }

    [Parameter]
    public MemorabiliaSearchCriteria Filter { get; set; }

    [Parameter]
    public int UserId { get; set; }

    protected bool DisplayLoadMoreButton
        => Model?.PageInfo?.TotalItems > _pageSize;

    protected MemorabiliaGalleryItemsModel Model;

    private MemorabiliaSearchCriteria _filter = new();
    private List<MemorabiliaGalleryItemModel> _items = new();
    private readonly int _pageSize = 12;

    protected override async Task OnParametersSetAsync()
    {
        if (_filter == Filter)
            return;

        _filter = Filter;

        await LoadItems(1, true);
    }

    protected string GetDescription(MemorabiliaGalleryItemModel item)
    {
        return GalleryService.GetDescription(item.Memorabilia);
    }

    protected string GetSubtitle(MemorabiliaGalleryItemModel item)
    {
        return GalleryService.GetSubtitle(item.Memorabilia);
    }

    protected string GetTitle(MemorabiliaGalleryItemModel item)
    {
        return GalleryService.GetTitle(item.Memorabilia);
    }

    private async void LoadMore()
    {
        await LoadItems(Model.PageInfo.PageNumber + 1);
    }

    private async Task LoadItems(int pageNumber, bool resetItems = false)
    {
        var pageInfo = new PageInfo(pageNumber, _pageSize);

        Model = _filter != null
            ? await QueryRouter.Send(new GetCollectionMemorabiliaGalleryItems(CollectionId, pageInfo, _filter))
            : await QueryRouter.Send(new GetCollectionMemorabiliaGalleryItems(CollectionId, pageInfo));

        if (resetItems)
            _items = new();

        _items.AddRange(Model.Items);
    }
}
