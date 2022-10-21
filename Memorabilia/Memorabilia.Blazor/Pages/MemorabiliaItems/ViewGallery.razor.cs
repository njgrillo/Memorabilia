#nullable disable

using Memorabilia.Application.Features.Services.Gallery.Memorabilia;

namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public partial class ViewGallery : ComponentBase
{
    [Inject]
    public IGalleryService GalleryService { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int UserId { get; set; }

    private List<MemorabiliaGalleryItemViewModel> _displayedItems;
    private bool _displayLoadMoreButton;
    private bool _displaySpinner;
    private int _index = 12;
    private List<MemorabiliaGalleryItemViewModel> _initialItems;
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
    
    private void LoadMore()
    {
        var range = new Range(_index, _index + 12);
        var items = _viewModel.Items.Take(range).ToList();

        _displayedItems.AddRange(items);

        _index += 12;
        _displayLoadMoreButton = _viewModel.Items.Count() > _index;
    }

    protected void OnFilter(IEnumerable<int> ids)
    {
        _index = 12;

        _viewModel.Items = _initialItems.Where(item => ids.Contains(item.Id));
        _displayedItems = _viewModel.Items.Take(Math.Min(_index, _viewModel.Items.Count())).ToList();
        _displayLoadMoreButton = _viewModel.Items.Count() > _index;
    }

    protected async Task OnLoad()
    {
         _viewModel = await QueryRouter.Send(new GetMemorabiliaGalleryItems(UserId));
        _initialItems = _viewModel.Items.ToList();
        _displayedItems = _initialItems.Take(_index).ToList();
        _displayLoadMoreButton = _viewModel.Items.Count() > _index;
    }
}
