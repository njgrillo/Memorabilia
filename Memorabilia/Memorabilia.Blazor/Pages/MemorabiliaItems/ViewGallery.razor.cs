#nullable disable

namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public partial class ViewGallery : ImagePage
{
    [Inject]
    public IGalleryService GalleryService { get; set; }

    [Parameter]
    public int UserId { get; set; }

    private bool DisplayLoadMoreButton => _viewModel?.PageInfo?.TotalItems > _pageSize;
    private IMemorabiliaFilterPredicateBuilder _filter;
    private List<MemorabiliaGalleryItemViewModel> _items = new();
    private readonly int _pageSize = 12;
    private MemorabiliaGalleryItemsViewModel _viewModel;

    protected string GetDescription(MemorabiliaGalleryItemViewModel item)
    {
        return GalleryService.GetDescription(item.Memorabilia);
    }

    protected string GetSubtitle(MemorabiliaGalleryItemViewModel item)
    {
        return GalleryService.GetSubtitle(item.Memorabilia);
    }

    protected string GetTitle(MemorabiliaGalleryItemViewModel item)
    {
        return GalleryService.GetTitle(item.Memorabilia);
    }
    
    private async void LoadMore()
    {
        await LoadItems(_viewModel.PageInfo.PageNumber + 1);
    }

    protected async Task OnFilter(IMemorabiliaFilterPredicateBuilder filter)
    {
        _filter = filter;

        await LoadItems(1, true);
    }

    protected async Task OnLoad()
    {
        await LoadItems(1);
    }

    private async Task LoadItems(int pageNumber, bool resetItems = false)
    {
        var pageInfo = new PageInfo(pageNumber, _pageSize);

        _viewModel = _filter != null
            ? await QueryRouter.Send(new GetMemorabiliaGalleryItems(UserId, pageInfo, _filter.Predicate))
            : await QueryRouter.Send(new GetMemorabiliaGalleryItems(UserId, pageInfo));

        if (resetItems)
            _items = new();

        _items.AddRange(_viewModel.Items);
    }
}
