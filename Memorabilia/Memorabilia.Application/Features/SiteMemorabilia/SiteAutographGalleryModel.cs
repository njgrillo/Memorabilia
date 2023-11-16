namespace Memorabilia.Application.Features.SiteMemorabilia;

public class SiteAutographGalleryModel(Entity.Autograph autograph)
{
    public string ImageFileName =>
        !autograph.Person.ImageFileName.IsNullOrEmpty()
            ? autograph.Person.ImageFileName
            : Constant.ImageFileName.ImageNotAvailable;

    public string ImageNavigationPath
        => autograph.Person.Sports.Count != 0
            ? $"/Tools/{autograph.Person.Sports.First().Sport.Name}Profile/{autograph.Person.Id}"
            : "/Tools/PersonProfile";

    public string PersonName
        => autograph.Person.ProfileName;
}
