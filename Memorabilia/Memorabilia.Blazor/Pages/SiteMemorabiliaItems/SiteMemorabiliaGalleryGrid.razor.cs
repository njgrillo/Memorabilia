namespace Memorabilia.Blazor.Pages.SiteMemorabiliaItems;

public partial class SiteMemorabiliaGalleryGrid
{
    [Inject]
    public IGalleryService GalleryService { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public MemorabiliaSearchCriteria Filter { get; set; }

    protected bool DisplayLoadMoreButton
        => Model?.PageInfo?.TotalItems > _pageSize;

    protected SiteMemorabiliaGalleryItemsModel Model; 

    private List<SiteMemorabiliaGalleryItemModel> _items
        = new();

    private readonly int _pageSize
        = 12;

    protected override async Task OnParametersSetAsync()
    {
        await LoadItems(1, true);
    }

    protected string GetDescription(SiteMemorabiliaGalleryItemModel item)
        => GalleryService.GetDescription(item.Memorabilia);

    protected string GetSubtitle(SiteMemorabiliaGalleryItemModel item)
        => GalleryService.GetSubtitle(item.Memorabilia);

    protected string GetTitle(SiteMemorabiliaGalleryItemModel item) 
        => GalleryService.GetTitle(item.Memorabilia);

    private async void LoadMore()
    {
        await LoadItems(Model.PageInfo.PageNumber + 1);
    }

    private async Task LoadItems(int pageNumber, bool resetItems = false)
    {
        var pageInfo = new PageInfo(pageNumber, _pageSize);

        Model = Filter != null
            ? await QueryRouter.Send(new GetSiteMemorabiliaGalleryItems(pageInfo, Filter))
            : await QueryRouter.Send(new GetSiteMemorabiliaGalleryItems(pageInfo));

        if (resetItems)
            _items = new();

        _items.AddRange(Model.Items);
    }
}
