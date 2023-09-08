namespace Memorabilia.Application.Features.SiteMemorabilia;

public class SiteAutographGalleryModel
{
    private readonly Entity.Autograph _autograph;

    public SiteAutographGalleryModel(Entity.Autograph autograph)
    {
        _autograph = autograph;
    }

    public string ImageFileName =>
        !_autograph.Person.ImageFileName.IsNullOrEmpty()
            ? _autograph.Person.ImageFileName
            : Constant.ImageFileName.ImageNotAvailable;

    public string ImageNavigationPath
        => _autograph.Person.Sports.Any()
            ? $"/Tools/{_autograph.Person.Sports.First().Sport.Name}Profile/{_autograph.Person.Id}"
            : "/Tools/PersonProfile";

    public string PersonName
        => _autograph.Person.ProfileName;
}
