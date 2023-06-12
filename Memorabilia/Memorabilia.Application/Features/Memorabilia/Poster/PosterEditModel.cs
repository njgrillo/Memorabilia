namespace Memorabilia.Application.Features.Memorabilia.Poster;

public class PosterEditModel : MemorabiliaItemEditModel
{
    public PosterEditModel() 
    { 
        BrandId = Constant.Brand.None.Id;
        SizeId = Constant.Size.TwentyByThirty.Id;
    }

    public PosterEditModel(PosterModel model)
    {
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
        => Constant.ImageFileName.Poster;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Poster;

    public bool Matted { get; set; }

    public int OrientationId { get; set; } 
        = Constant.Orientation.Portrait.Id;    
}
