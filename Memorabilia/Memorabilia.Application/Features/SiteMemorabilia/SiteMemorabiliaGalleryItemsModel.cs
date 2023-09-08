namespace Memorabilia.Application.Features.SiteMemorabilia;

public class SiteMemorabiliaGalleryItemsModel : Model
{
    public SiteMemorabiliaGalleryItemsModel(IEnumerable<Entity.Memorabilia> items,
                                            PageInfoResult pageInfo = null)
    {
        Items = items.Select(item => new SiteMemorabiliaGalleryItemModel(item));
        PageInfo = pageInfo;
    }

    public IEnumerable<SiteMemorabiliaGalleryItemModel> Items { get; set; }
        = Enumerable.Empty<SiteMemorabiliaGalleryItemModel>();
}
