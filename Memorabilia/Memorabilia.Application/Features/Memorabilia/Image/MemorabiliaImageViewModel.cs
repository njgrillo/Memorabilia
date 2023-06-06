namespace Memorabilia.Application.Features.Memorabilia.Image;

public class MemorabiliaImageViewModel : ImageModel
{
    private readonly Entity.MemorabiliaImage _image;

    public MemorabiliaImageViewModel() { }

    public MemorabiliaImageViewModel(Entity.MemorabiliaImage image) : base(image)
    {
        _image = image;
    }

    public int MemorabiliaId => _image.MemorabiliaId;
}
