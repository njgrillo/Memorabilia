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

    public string ImageFileName
    {
        get
        {
            var primaryImageFileName = _autograph.Images.Any()
                ? _autograph.Images.SingleOrDefault(image => image.ImageTypeId == ImageType.Primary.Id)?.FileName ?? Domain.Constants.ImageFileName.ImageNotAvailable
                : Domain.Constants.ImageFileName.ImageNotAvailable;

            return !primaryImageFileName.IsNullOrEmpty() ? primaryImageFileName : Domain.Constants.ImageFileName.ImageNotAvailable;
        }
    }

    public string ImageNavigationPath => $"/Autographs/Image/{EditModeType.Update.Name}/{_autograph.Id}";

    public string PersonName => _autograph.Person.ProfileName;
}
