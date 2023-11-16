namespace Memorabilia.Application.Features.Autograph.Gallery;

public class AutographGalleryModel(Entity.Autograph autograph)
{
    public int AutographId
        => autograph.Id;

    public string ImageFileName 
        => !autograph.Person.ImageFileName.IsNullOrEmpty()
           ? autograph.Person.ImageFileName
           : Constant.ImageFileName.ImageNotAvailable;

    public int MemorabiliaId
        => autograph.MemorabiliaId;

    public Entity.Person Person
        => autograph.Person;

    public string PersonName 
        => autograph.Person.ProfileName;
}
