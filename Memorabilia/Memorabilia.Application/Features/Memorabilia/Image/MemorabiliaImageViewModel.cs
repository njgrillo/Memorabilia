namespace Memorabilia.Application.Features.Memorabilia.Image;

public class MemorabiliaImageViewModel : ImageModel
{
    private readonly Domain.Entities.MemorabiliaImage _image;

    public MemorabiliaImageViewModel() { }

    public MemorabiliaImageViewModel(Domain.Entities.MemorabiliaImage image) : base(image)
    {
        _image = image;
    }

    public int MemorabiliaId => _image.MemorabiliaId;
}
