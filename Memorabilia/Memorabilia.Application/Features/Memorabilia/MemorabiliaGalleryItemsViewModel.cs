namespace Memorabilia.Application.Features.Memorabilia;

public class MemorabiliaGalleryItemsViewModel
{
	public MemorabiliaGalleryItemsViewModel(IEnumerable<Domain.Entities.Memorabilia> items)
	{
		FilterItems = items.Select(item => new MemorabiliaItemViewModel(item));
		Items = items.Select(item => new MemorabiliaGalleryItemViewModel(item));
	}

	public IEnumerable<MemorabiliaItemViewModel> FilterItems { get; set; } = Enumerable.Empty<MemorabiliaItemViewModel>();

	public IEnumerable<MemorabiliaGalleryItemViewModel> Items { get; set; } = Enumerable.Empty<MemorabiliaGalleryItemViewModel>();
}
