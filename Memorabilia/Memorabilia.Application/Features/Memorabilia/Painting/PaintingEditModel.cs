namespace Memorabilia.Application.Features.Memorabilia.Painting;

public class PaintingEditModel : MemorabiliaItemEditModel
{
    public PaintingEditModel()
    {
        BrandId = Constant.Brand.None.Id;
        SizeId = Constant.Size.EightByTen.Id;
    }

    public PaintingEditModel(PaintingModel model)
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
        => Constant.ImageFileName.Painting;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Painting;

    public bool Matted { get; set; }

    public int OrientationId { get; set; } 
        = Constant.Orientation.Portrait.Id;
}
