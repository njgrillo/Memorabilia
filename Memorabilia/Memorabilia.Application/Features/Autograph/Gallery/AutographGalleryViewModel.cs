using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Autograph.Gallery;

public class AutographGalleryViewModel
{
    private readonly Domain.Entities.Autograph _autograph;

    public AutographGalleryViewModel(Domain.Entities.Autograph autograph)
    {
        _autograph = autograph;
    }

    public string EditNavigationPath => $"/Autographs/{EditModeType.Update.Name}/{_autograph.MemorabiliaId}/{_autograph.Id}";

    public string ImageNavigationPath => $"/Autographs/Image/{EditModeType.Update.Name}/{_autograph.Id}";

    public string PersonName => _autograph.Person.ProfileName;

    public string PrimaryImagePath
    {
        get
        {
            var primaryImagePath = _autograph.Images.Any()
                ? _autograph.Images.SingleOrDefault(image => image.ImageTypeId == Domain.Constants.ImageType.Primary.Id)?.FilePath ?? ImagePath.ImageNotAvailable
                : ImagePath.ImageNotAvailable;

            if (primaryImagePath.IsNullOrEmpty() || !File.Exists(primaryImagePath))
                primaryImagePath = ImagePath.ImageNotAvailable;

            return $"data:image/jpeg;base64,{Convert.ToBase64String(File.ReadAllBytes(primaryImagePath))}";
        }
    }
}
