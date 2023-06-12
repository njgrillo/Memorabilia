namespace Memorabilia.Application.Features.Memorabilia.Lithograph;

public class LithographEditModel : MemorabiliaItemEditModel
{
    public LithographEditModel()
    { 
        BrandId = Constant.Brand.None.Id;
        SizeId = Constant.Size.EightByTen.Id;
    }

    public LithographEditModel(LithographModel model)
    {
        BrandId = model.Brand.BrandId;
        Matted = model.Picture.Matted;
        MemorabiliaId = model.MemorabiliaId;
        OrientationId = model.Picture.OrientationId;

        People = model.People
                      .Select(person => person.Person.ToEditModel())
                      .ToList();

        SizeId = model.Size.SizeId;

        SportIds = model.Sports
                        .Select(sport => sport.SportId)
                        .ToList();

        Teams = model.Teams
                     .Select(team => team.Team.ToEditModel())
                     .ToList();
    }

    public override string ImageFileName 
        => Constant.ImageFileName.Lithograph;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Lithograph;

    public bool Matted { get; set; }

    public int OrientationId { get; set; } 
        = Constant.Orientation.Portrait.Id;
}
