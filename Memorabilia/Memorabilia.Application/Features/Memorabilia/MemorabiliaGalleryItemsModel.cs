namespace Memorabilia.Application.Features.Memorabilia;

public class MemorabiliaGalleryItemsModel : ViewModel
{
	public MemorabiliaGalleryItemsModel(IEnumerable<Entity.Memorabilia> items,
                                        PageInfoResult pageInfo = null)
	{
		Items = items.Select(item => new MemorabiliaGalleryItemModel(item));
        PageInfo = pageInfo;
    }

	public IEnumerable<MemorabiliaGalleryItemModel> Items { get; set; }
		= Enumerable.Empty<MemorabiliaGalleryItemModel>();
}
