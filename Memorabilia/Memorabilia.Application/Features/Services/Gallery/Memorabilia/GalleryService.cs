namespace Memorabilia.Application.Features.Services.Gallery.Memorabilia;

public class GalleryService : IGalleryService
{
    private readonly IGalleryRuleFactory _galleryRuleFactory;

    public GalleryService(IGalleryRuleFactory galleryRuleFactory)
    {
        _galleryRuleFactory = galleryRuleFactory;
    }

    public string GetDescription(Entity.Memorabilia memorabilia)
    {
        foreach (var rule in _galleryRuleFactory.Rules)
        {
            if (rule.Applies(memorabilia.ItemType))
            {
                return rule.GetDescription(memorabilia);
            }
        }

        return string.Empty;
    }

    public string GetSubtitle(Entity.Memorabilia memorabilia)
    {
        foreach (var rule in _galleryRuleFactory.Rules)
        {
            if (rule.Applies(memorabilia.ItemType))
            {
                return rule.GetSubtitle(memorabilia);
            }
        }

        return string.Empty;
    }

    public string GetTitle(Entity.Memorabilia memorabilia)
    {
        foreach(var rule in _galleryRuleFactory.Rules)
        {
            if (rule.Applies(memorabilia.ItemType))
            {
                return rule.GetTitle(memorabilia);
            }
        }

        return string.Empty;
    }
}
