namespace Memorabilia.Application.Features.Memorabilia.Magazine;

public class MagazineEditModel : MemorabiliaItemEditModel
{
    public MagazineEditModel()
    { 
        SizeId = Constant.Size.Standard.Id;
    }

    public MagazineEditModel(MagazineModel model)
    {
        BrandId = model.Brand.BrandId;
        Date = model.Magazine.Date;
        Framed = model.Magazine.Framed;
        Matted = model.Magazine.Matted;
        MemorabiliaId = model.MemorabiliaId;
        OrientationId = model.Magazine.OrientationId;

        People = model.People
                      .Select(person => person.Person.ToEditModel())
                      .ToList();

        SizeId = model.Size.SizeId;

        SportIds = model.Sports
                        .Select(x => x.SportId)
                        .ToList();

        Teams = model.Teams
                     .Select(team => team.Team.ToEditModel())
                     .ToList();
    }

    public DateTime? Date { get; set; }

    public bool Framed { get; set; }

    public override string ImageFileName 
        => Constant.ImageFileName.Magazine;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Magazine;

    public bool Matted { get; set; }

    public int OrientationId { get; set; } 
        = Constant.Orientation.Portrait.Id;
}
