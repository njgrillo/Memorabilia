namespace Memorabilia.Application.Services.Gallery.Memorabilia;

public class GalleryRuleFactory : IGalleryRuleFactory
{
    public List<IGalleryRule> Rules { get; set; }
        = [];

    public GalleryRuleFactory()
    {
        Rules.Add(new BaseballGalleryRule());
        Rules.Add(new HelmetGalleryRule());
        Rules.Add(new JerseyGalleryRule());
        Rules.Add(new PhotoGalleryRule());
    }
}
