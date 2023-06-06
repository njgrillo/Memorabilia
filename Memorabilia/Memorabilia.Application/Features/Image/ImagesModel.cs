namespace Memorabilia.Application.Features.Image;

public class ImagesModel : ViewModel
{
    public ImagesModel() { }

    public ImagesModel(IEnumerable<Entity.Image> images)
    {
        Images = images.Select(image => new ImageModel(image));
    }

    public virtual IEnumerable<ImageModel> Images { get; set; } 
        = Enumerable.Empty<ImageModel>();

    public override string PageTitle => "Images";
}
