namespace Memorabilia.Application.Features.Services.Gallery.Memorabilia;

public class GalleryRuleFactory : IGalleryRuleFactory
{
    public List<IGalleryRule> Rules { get; set; } = new();

    public GalleryRuleFactory()
    {
        Rules.Add(new BaseballGalleryRule());
        Rules.Add(new HelmetGalleryRule());
    }
}
