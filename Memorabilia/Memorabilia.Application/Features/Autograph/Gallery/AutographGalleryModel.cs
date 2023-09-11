namespace Memorabilia.Application.Features.Autograph.Gallery;

public class AutographGalleryModel
{
    private readonly Entity.Autograph _autograph;

    public AutographGalleryModel(Entity.Autograph autograph)
    {
        _autograph = autograph;
    }

    public int AutographId
        => _autograph.Id;

    public string ImageFileName =>
        !_autograph.Person.ImageFileName.IsNullOrEmpty()
            ? _autograph.Person.ImageFileName
            : Constant.ImageFileName.ImageNotAvailable;

    public int MemorabiliaId
        => _autograph.MemorabiliaId;

    public Entity.Person Person
        => _autograph.Person;

    public string PersonName 
        => _autograph.Person.ProfileName;
}
