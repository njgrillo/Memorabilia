namespace Memorabilia.Blazor.Pages.Collection;

public partial class CollectionMemorabiliaGalleryGrid
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IGalleryService GalleryService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Parameter]
    public int CollectionId { get; set; }

    [Parameter]
    public MemorabiliaSearchCriteria Filter { get; set; }

    protected bool DisplayLoadMoreButton
        => Model?.PageInfo?.TotalItems > _pageSize;

    protected MemorabiliaGalleryItemsModel Model;

    private List<MemorabiliaGalleryItemModel> _items 
        = [];

    private readonly int _pageSize 
        = 12;

    protected override async Task OnParametersSetAsync()
    {
        await LoadItems(1, true);
    }

    protected string GetDescription(MemorabiliaGalleryItemModel item)
        => GalleryService.GetDescription(item.Memorabilia);

    protected string GetSubtitle(MemorabiliaGalleryItemModel item)
        => GalleryService.GetSubtitle(item.Memorabilia);

    protected string GetTitle(MemorabiliaGalleryItemModel item)
        => GalleryService.GetTitle(item.Memorabilia);

    private async void LoadMore()
    {
        await LoadItems(Model.PageInfo.PageNumber + 1);
    }

    private async Task LoadItems(int pageNumber, bool resetItems = false)
    {
        var pageInfo = new PageInfo(pageNumber, _pageSize);

        Model = await Mediator.Send(new GetCollectionMemorabiliaGalleryItemsPaged(CollectionId, pageInfo, Filter));

        if (resetItems)
            _items = [];

        _items.AddRange(Model.Items);
    }
}
