namespace Memorabilia.Application.Features.Services.Gallery.Memorabilia;

public class GalleryService(IGalleryRuleFactory galleryRuleFactory) 
    : IGalleryService
{
    public string GetDescription(Entity.Memorabilia memorabilia)
    {
        foreach (IGalleryRule rule in galleryRuleFactory.Rules)
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
        foreach (IGalleryRule rule in galleryRuleFactory.Rules)
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
        foreach (IGalleryRule rule in galleryRuleFactory.Rules)
        {
            if (rule.Applies(memorabilia.ItemType))
            {
                return rule.GetTitle(memorabilia);
            }
        }

        return string.Empty;
    }
}
