namespace Memorabilia.Application.Features.Memorabilia.Figure;

public class FigureEditModel : MemorabiliaItemEditModel
{
    public FigureEditModel() 
    { 
        LevelTypeId = Constant.LevelType.Professional.Id;
        SizeId = Constant.Size.Standard.Id;
    }

    public FigureEditModel(FigureModel model)
    {
        BrandId = model.Brand.BrandId;
        FigureSpecialtyTypeId = model.Figure?.FigureSpecialtyTypeId ?? 0;
        FigureTypeId = model.Figure?.FigureTypeId ?? 0;
        LevelTypeId = model.Level.LevelTypeId;
        MemorabiliaId = model.MemorabiliaId;

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

        Year = model.Figure?.Year;
    }

    public int FigureSpecialtyTypeId { get; set; }

    public Constant.FigureType FigureType 
        => Constant.FigureType.Find(FigureTypeId);

    public int FigureTypeId { get; set; }

    public override string ImageFileName 
        => Constant.ImageFileName.Figure;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Figure;

    public int? Year { get; set; }
}
