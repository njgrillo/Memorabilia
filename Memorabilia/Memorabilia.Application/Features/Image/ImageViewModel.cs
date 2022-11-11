using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Image;

public class ImageViewModel
{
    private readonly Domain.Entities.Image _image;

    public ImageViewModel() { }

    public ImageViewModel(Domain.Entities.Image image)
    {
        _image = image;
    }

    public string FileName => _image.FileName;
    
    public int Id => _image.Id;

    public int ImageTypeId => _image.ImageTypeId;

    public bool IsPrimary => _image.ImageTypeId == ImageType.Primary.Id;

    public DateTime UploadDate => _image.UploadDate;
}
