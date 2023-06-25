namespace Memorabilia.Application.Features.Memorabilia.Photo;

public class PhotoEditModel : MemorabiliaItemEditModel
{
    public PhotoEditModel() 
    { 
        BrandId = Constant.Brand.None.Id;
    }

    public PhotoEditModel(PhotoModel model)
    {
        BrandId = model.Brand.BrandId;
        Matted = model.Picture.Matted;
        MemorabiliaId = model.MemorabiliaId;
        OrientationId = model.Picture.OrientationId;

        People = model.People
                      .Select(person => person.Person.ToEditModel())
                      .ToList();

        PhotoTypeId = model.Picture.PhotoTypeId ?? 0;
        SizeId = model.Size.SizeId;

        SportIds = model.Sports
                        .Select(sport => sport.SportId)
                        .ToList();

        Teams = model.Teams
                     .Select(team => team.Team.ToEditModel())
                     .ToList();
    }

    public override string ImageFileName
        => Constant.ImageFileName.Photo;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Photo;       
    
    public bool Matted { get; set; }

    public int OrientationId { get; set; }
        = Constant.Orientation.Portrait.Id;

    public int PhotoTypeId { get; set; } 
        = Constant.PhotoType.Glossy.Id;
}
