using Memorabilia.Application.Services.Gallery.Memorabilia;
using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public partial class MemorabiliaGalleryGrid
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IGalleryService GalleryService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

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

    private string GetEditNavigationPath(int id)
        => $"{NavigationPath.Memorabilia}/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(id)}";

    private string GetPrimaryImageNavigationPath(int id)
        => $"{NavigationPath.MemorabiliaImage}/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(id)}";

    private async void LoadMore()
    {
        await LoadItems(Model.PageInfo.PageNumber + 1);
    }

    private async Task LoadItems(int pageNumber, bool resetItems = false)
    {
        var pageInfo = new PageInfo(pageNumber, _pageSize);

        Model = Filter != null
            ? await Mediator.Send(new GetMemorabiliaGalleryItems(pageInfo, Filter))
            : await Mediator.Send(new GetMemorabiliaGalleryItems(pageInfo));

        if (resetItems)
            _items = [];

        _items.AddRange(Model.Items);
    }
}
