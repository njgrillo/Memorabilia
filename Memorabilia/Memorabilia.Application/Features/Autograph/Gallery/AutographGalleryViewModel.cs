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

    public string ImageFileName =>
        !_autograph.Person.ImageFileName.IsNullOrEmpty()
            ? _autograph.Person.ImageFileName
            : Domain.Constants.ImageFileName.ImageNotAvailable;

    public string ImageNavigationPath
    {
        get
        {
            return _autograph.Person.Sports.Any()
            ? $"/Tools/{_autograph.Person.Sports.First().Sport.Name}Profile/{_autograph.Person.Id}"
            : "/Tools/PersonProfile";
        } 
    }

    public string PersonName => _autograph.Person.ProfileName;
}
