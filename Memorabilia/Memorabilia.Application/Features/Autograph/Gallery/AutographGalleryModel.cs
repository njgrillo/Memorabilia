namespace Memorabilia.Application.Features.Autograph.Gallery;

public class AutographGalleryModel
{
    private readonly Entity.Autograph _autograph;

    public AutographGalleryModel(Entity.Autograph autograph)
    {
        _autograph = autograph;
    }

    public string EditNavigationPath 
        => $"/Autographs/{Constant.EditModeType.Update.Name}/{_autograph.MemorabiliaId}/{_autograph.Id}";

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
