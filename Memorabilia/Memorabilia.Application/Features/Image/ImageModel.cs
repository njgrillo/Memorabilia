namespace Memorabilia.Application.Features.Image;

public class ImageModel
{
    private readonly Entity.Image _image;

    public ImageModel() { }

    public ImageModel(Entity.Image image)
    {
        _image = image;
    }

    public string FileName 
        => _image.FileName;
    
    public int Id => _image.Id;

    public int ImageTypeId 
        => _image.ImageTypeId;

    public bool IsPrimary 
        => _image.ImageTypeId == Constant.ImageType.Primary.Id;

    public DateTime UploadDate 
        => _image.UploadDate;
}
