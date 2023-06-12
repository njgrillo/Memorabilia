namespace Memorabilia.Application.Features.Memorabilia.Canvas;

public class CanvasEditModel : MemorabiliaItemEditModel
{
    public CanvasEditModel() 
    {
        BrandId = Constant.Brand.None.Id;
        SizeId = Constant.Size.TwentyByThirty.Id;
    }

    public CanvasEditModel(CanvasModel model)
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

        Stretched = model.Picture.Stretched;

        Teams = model.Teams
                     .Select(team => team.Team.ToEditModel())
                     .ToList();
    }

    public override string ImageFileName 
        => Constant.ImageFileName.Canvas;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Canvas;

    public bool Matted { get; set; }

    public int OrientationId { get; set; } 
        = Constant.Orientation.Portrait.Id;

    public bool Stretched { get; set; }
}
