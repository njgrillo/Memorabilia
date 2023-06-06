namespace Memorabilia.Application.Features.Autograph.Image;

public class AutographImagesModel : ViewModel
{
    public AutographImagesModel() { }

    public AutographImagesModel(IEnumerable<Entity.AutographImage> images)
    {
        Images = images.Select(image => new AutographImageModel(image));
    }

    public IEnumerable<AutographImageModel> Images { get; set; } 
        = Enumerable.Empty<AutographImageModel>();

    public override string PageTitle => "Autograph Images";
}
