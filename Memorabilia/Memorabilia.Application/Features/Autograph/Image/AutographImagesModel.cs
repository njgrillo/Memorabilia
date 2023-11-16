namespace Memorabilia.Application.Features.Autograph.Image;

public class AutographImagesModel : Model
{
    public AutographImagesModel() { }

    public AutographImagesModel(IEnumerable<Entity.AutographImage> images)
    {
        Images = images.Select(image => new AutographImageModel(image))
                       .ToList();
    }

    public List<AutographImageModel> Images { get; set; } 
        = [];

    public override string PageTitle 
        => "Autograph Images";
}
