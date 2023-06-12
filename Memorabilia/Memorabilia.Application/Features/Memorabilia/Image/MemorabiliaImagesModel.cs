namespace Memorabilia.Application.Features.Memorabilia.Image;

public class MemorabiliaImagesModel : Model
{
    public MemorabiliaImagesModel() { }

    public MemorabiliaImagesModel(Entity.MemorabiliaImage[] images)
    {
        Images = images.Select(image => new MemorabiliaImageModel(image));
    }

    public IEnumerable<MemorabiliaImageModel> Images { get; set; } 
        = Enumerable.Empty<MemorabiliaImageModel>();

    public override string PageTitle 
        => "Memorabilia Images";
}
