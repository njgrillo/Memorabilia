namespace Memorabilia.Application.Features.Memorabilia.Image;

public class MemorabiliaImageModel : ImageModel
{
    private readonly Entity.MemorabiliaImage _image;

    public MemorabiliaImageModel() { }

    public MemorabiliaImageModel(Entity.MemorabiliaImage image) : base(image)
    {
        _image = image;
    }

    public int MemorabiliaId 
        => _image.MemorabiliaId;
}
