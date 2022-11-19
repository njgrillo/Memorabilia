namespace Memorabilia.Application.Features.Memorabilia;

public class MemorabiliaGalleryItemsViewModel : ViewModel
{
	public MemorabiliaGalleryItemsViewModel(IEnumerable<Domain.Entities.Memorabilia> items,
                                            PageInfoResult pageInfo = null)
	{
		Items = items.Select(item => new MemorabiliaGalleryItemViewModel(item));
        PageInfo = pageInfo;
    }

	public IEnumerable<MemorabiliaGalleryItemViewModel> Items { get; set; } = Enumerable.Empty<MemorabiliaGalleryItemViewModel>();
}
